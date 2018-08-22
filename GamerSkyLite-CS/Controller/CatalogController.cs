using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GamerSkyLite_CS.Controller
{
    /// <summary>
    /// 目录控制器
    /// </summary>
    public class CatalogController
    {
        /// <summary>
        /// 联网更新文章目录并存储进数据库
        /// </summary>
        /// <param name="CatalogAddress">文章目录地址</param>
        /// <param name="UnityDBController">数据库连接</param>
        public static void GetCatalog(string CatalogAddress)
        {
            UnityModule.DebugPrint("更新文章目录：{0}", CatalogAddress);
            string CatalogString = string.Empty;
            //下载目录信息
            using (WebClient UnityWebClient = new WebClient()
            {
                BaseAddress = CatalogAddress,
                Encoding = Encoding.UTF8,
            })
            {
                UnityWebClient.Headers.Add( HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                UnityWebClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");

                try
                {
                    CatalogString = UnityWebClient.DownloadString(CatalogAddress);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (CatalogString == string.Empty) throw new Exception("目录页面为空！");
            UnityModule.DebugPrint("下载文章目录成功！");

            //解析文章信息
            string CatalogPattern = "<([a-z]+)(?:(?!class)[^<>])*class=([\"']?){0}\\2[^>]*>(?>(?<o><\\1[^>]*>)|(?<-o></\\1>)|(?:(?!</?\\1).))*(?(o)(?!))</\\1>";
            CatalogPattern = string.Format(CatalogPattern, Regex.Escape("pictxt contentpaging"));
            CatalogString = new Regex(CatalogPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(CatalogString).Value;
            if (CatalogString == string.Empty) throw new Exception("目录匹配为空！");
            UnityModule.DebugPrint("正则匹配文章目录成功！");

            string[] CatalogList = Regex.Split(CatalogString, "</li>");
            if (CatalogList.Length == 0) throw new Exception("获取目录数据失败！");
            UnityModule.DebugPrint("分割文章目录成功！");

            CatalogPattern = "<a href.*?=.*?\"(?<ArticleLink>.+?)\".*?target=.*?\"_blank\">.*?<img src.*?=.*?\"(?<ImageLink>.+?)\" alt.*?title=\"(?<Title>.+?)\".*?>.*?<div Class.*?=.*?\"txt\".*?>(?<Description>.+?)</div>.*?<div Class.*?=.*?\"time\".*?>(?<PublishTime>.+?)</div>.*?<div.*?>";
            Regex CatalogRegex = new Regex(CatalogPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (string CatalogItem in CatalogList)
            {
                Match CatalogMatch = CatalogRegex.Match(CatalogItem);
                if (CatalogMatch.Success)
                {
                    UnityModule.DebugPrint("目录项正则分析成功！");
                    //使用 ImageLink 文件名称部分当做 ArticleID；
                    string Title = CatalogMatch.Groups["Title"].Value;
                    string ArticleLink = CatalogMatch.Groups["ArticleLink"].Value;
                    string ImageLink = CatalogMatch.Groups["ImageLink"].Value;
                    string Description = CatalogMatch.Groups["Description"].Value;
                    string PublishTime = CatalogMatch.Groups["PublishTime"].Value;
                    string ArticleID = Path.GetFileNameWithoutExtension(CatalogMatch.Groups["ImageLink"].Value);
                    string ImagePath = FileController.PathCombine(UnityModule.ContentDirectory, Path.GetFileName(CatalogMatch.Groups["ImageLink"].Value));

                    //预处理
                    if (!ArticleLink.StartsWith(UnityModule.WebSite)) ArticleLink = FileController.LinkCombine(UnityModule.WebSite, ArticleLink);
                    Title.Replace("'", "");
                    Description = Description.Replace("\n", "").Replace("'", "");
                    if (UnityModule.UnityDBController.ExecuteScalar("SELECT ArticleID FROM CatalogBase WHERE ArticleID=@ID", new Tuple<string, object>("@ID", ArticleID)) == null)
                    {
                        UnityModule.DebugPrint("》》》发现新文章：{0}", ArticleID);
                        UnityModule.UnityDBController.ExecuteNonQuery(
                            "INSERT INTO CatalogBase (ArticleID, Title, ArticleLink, ImagePath, ImageLink, Description, PublishTime, IsNew) VALUES(@ArticleID, @Title, @ArticleLink, @ImagePath, @ImageLink, @Description, @PublishTime, YES);",
                             new Tuple<string, object>("@ArticleID", ArticleID),
                             new Tuple<string, object>("@Title", Title),
                             new Tuple<string, object>("@ArticleLink", ArticleLink),
                             new Tuple<string, object>("@ImagePath", ImagePath),
                             new Tuple<string, object>("@ImageLink", ImageLink),
                             new Tuple<string, object>("@Description", Description),
                             new Tuple<string, object>("@PublishTime", PublishTime)
                        );
                    }
                    else
                    {
                        UnityModule.DebugPrint("》》》已经存在的文章：{0}", ArticleID);
                    }
                }
            }
        }
        
    }
}
