using System;
using System.Data;
using System.Data.OleDb;
using GamerSkyLite_CS;
using GamerSkyLite_CS.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamerSkyLite_CS
{
    partial class MainForm
    {
        /// <summary>
        /// 加载文章目录
        /// </summary>
        private void LoadCatalog()
        {
            UnityModule.DebugPrint("开始读取目录列表...");
            using (OleDbDataReader CatalogReader = UnityDBController.ExecuteReader("SELECT * FROM CatalogBase"))
            {
                if (CatalogReader == null) throw new Exception("未从数据库中查询到文章目录项。");
                if (CatalogReader.HasRows)
                {
                    while (CatalogReader.Read())
                    {
                        ArticleCard NewArticleCard = new ArticleCard()
                        {
                            ArticleID = CatalogReader["ArticleID"] as string,
                            Title = CatalogReader["Title"] as string,
                            ArticleLink = CatalogReader["ArticleLink"] as string,
                            ImageLink = CatalogReader["ImageLink"] as string,
                            ImagePath = CatalogReader["ImagePath"] as string,
                            Description = CatalogReader["Description"] as string,
                            PublishTime = CatalogReader["PublishTime"] as string,
                        };
                        UnityModule.DebugPrint("读取到文章：{0}-{1}", NewArticleCard.ArticleID, NewArticleCard.Title);

                        CatalohLayoutPanel.Controls.Add(NewArticleCard);
                        NewArticleCard.Show();
                    }
                }
                CatalogReader.Close();
            }
        }

    }
}
