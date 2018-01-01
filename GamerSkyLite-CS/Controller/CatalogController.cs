using System;
using System.Collections.Generic;
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
        public static void GetCatalog(string CatalogAddress,DataBaseController UnityDBController)
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

            //解析文章信息
            string CatalogPattern = "<([a-z]+)(?:(?!class)[^<>])*class=([\"']?){0}\\2[^>]*>(?>(?<o><\\1[^>]*>)|(?<-o></\\1>)|(?:(?!</?\\1).))*(?(o)(?!))</\\1>";
            CatalogPattern = string.Format(CatalogPattern, Regex.Escape("pictxt contentpaging"));
            CatalogString = new Regex(CatalogPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(CatalogString).Value;
            if (CatalogString == string.Empty) throw new Exception("目录匹配为空！");

            string[] CatalogList = Regex.Split(CatalogString, "</li>");
            if (CatalogList.Length == 0) throw new Exception("获取目录数据失败！");

            CatalogPattern = "<a href.*?=.*?\"(?<ArticleLink>.+?)\".*?target=.*?\"_blank\">.*?<img src.*?=.*?\"(?<ImagePath>.+?)\" alt.*?title=\"(?<Title>.+?)\".*?>.*?<div Class.*?=.*?\"txt\".*?>(?<Description>.+?)</div>.*?<div Class.*?=.*?\"time\".*?>(?<Time>.+?)</div>.*?<div.*?>";
            Regex CatalogRegex = new Regex(CatalogPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (string CatalogItem in CatalogList)
            {
                Match CatalogMatch = CatalogRegex.Match(CatalogItem);
                if (CatalogMatch.Success)
                {
                    //使用 ImagePath 文件名称部分当做 ArticleID；
                    string Title = CatalogMatch.Groups["Title"].Value;
                    string ArticleLink = CatalogMatch.Groups["ArticleLink"].Value;
                    string ImagePath = CatalogMatch.Groups["ImagePath"].Value;
                    string Description = CatalogMatch.Groups["Description"].Value;
                    string PublishTime = CatalogMatch.Groups["PublishTime"].Value;
                    string ArticleID = Path.GetFileNameWithoutExtension(CatalogMatch.Groups["ImagePath"].Value);

                    //预处理
                    if (!ArticleLink.StartsWith(UnityModule.WebSite)) ArticleLink = FileController.LinkCombine(UnityModule.WebSite, ArticleLink);
                    Description = Description.Replace("\n", "");

                    if (UnityDBController.ExecuteScalar("SELECT ArticleID FROM CatalogBase WHERE ArticleID='{0}'", ArticleID) == null)
                    {
                        UnityDBController.ExecuteNonQuery("INSERT INTO CatalogBase (ArticleID, Title, ArticleLink, ImagePath, Description, PublishTime) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                            ArticleID, 
                            Title, 
                            ArticleLink, 
                            ImagePath, 
                            Description,
                            PublishTime
                        );
                    }
                }
            }
        }

    }
}
