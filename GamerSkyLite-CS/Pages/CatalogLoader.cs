using System;
using System.Data;
using System.Data.OleDb;
using GamerSkyLite_CS;
using GamerSkyLite_CS.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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
                    DateTime GroupDate = DateTime.MaxValue, TempDate=DateTime.Today;
                    while (CatalogReader.Read())
                    {
                        try
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
                            try
                            {
                                //按日期分割添加日期标签
                                TempDate = Convert.ToDateTime((CatalogReader["PublishTime"] as string).Split(' ').First()).Date;
                                if (TempDate != GroupDate)
                                {
                                    CatalogLayoutPanel.Controls.Add(new System.Windows.Forms.Label()
                                    {
                                        AutoSize = false,
                                        Size = new Size(150, 30),
                                        Font = new Font(this.Font.FontFamily, 11, System.Drawing.FontStyle.Bold),
                                        ForeColor = Color.DimGray,
                                        ImageAlign = ContentAlignment.MiddleLeft,
                                        TextAlign= ContentAlignment.MiddleRight,
                                        Image = UnityResource.ClockIcon,
                                        Padding = new Padding(3, 8, 3, 1),
                                        Text = TempDate.ToString("yyyy-MM-dd")
                                    });
                                    GroupDate = TempDate;
                                }
                            }
                            catch { }

                            CatalogLayoutPanel.Controls.Add(NewArticleCard);
                            NewArticleCard.Show();
                        }
                        catch(Exception ex)
                        {
                            UnityModule.DebugPrint("读取新文章属性时遇到错误：{0} == {1}", CatalogReader["PublishTime"], ex.Message);
                        }
                    }
                }
                CatalogReader.Close();
            }
        }

    }
}
