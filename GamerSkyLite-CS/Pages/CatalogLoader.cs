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
using System.Threading;
using System.IO;

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
            
            OleDbDataAdapter CatalogAdapter = null;
            lock (UnityModule.UnityDBController)
            {
                CatalogAdapter = UnityModule.UnityDBController.ExecuteAdapter("SELECT * FROM CatalogBase");
            }
            using (DataTable CatalogTable = new DataTable())
            {
                CatalogAdapter.Fill(CatalogTable);
                if (CatalogTable.Rows.Count>0)
                {
                    DateTime GroupDate = DateTime.MaxValue, TempDate = DateTime.Today;
                    foreach(DataRow CatalogRow in CatalogTable.Rows)
                    {
                        try
                        {
                            ArticleCard NewArticleCard = new ArticleCard(
                                CatalogRow["ArticleID"] as string,
                                CatalogRow["Title"] as string,
                                CatalogRow["Description"] as string,
                                CatalogRow["PublishTime"] as string,
                                CatalogRow["ImageLink"] as string,
                                CatalogRow["ImagePath"] as string,
                                CatalogRow["ArticleLink"] as string,
                                Convert.ToBoolean(CatalogRow["IsNew"])
                                )
                            {
                                Name = string.Format("Article_{0}", CatalogRow["ArticleID"] as string),
                            };
                            UnityModule.DebugPrint("读取到文章：{0}-{1}", NewArticleCard.ArticleID, NewArticleCard.Title);

                            //按日期分割添加日期标签
                            TempDate = Convert.ToDateTime((CatalogRow["PublishTime"] as string).Split(' ').First()).Date;
                            this.Invoke(new Action(() =>
                            {
                                if (TempDate != GroupDate)
                                {
                                    CatalogLayoutPanel.Controls.Add(new Label()
                                    {
                                        AutoSize = false,
                                        Size = new Size(150, 30),
                                        Font = new Font(this.Font.FontFamily, 11, System.Drawing.FontStyle.Bold),
                                        ForeColor = Color.DimGray,
                                        ImageAlign = ContentAlignment.MiddleLeft,
                                        TextAlign = ContentAlignment.MiddleRight,
                                        Image = UnityResource.ClockIcon,
                                        Padding = new Padding(3, 8, 3, 1),
                                        Text = TempDate.ToString("yyyy-MM-dd")
                                    });
                                GroupDate = TempDate;
                                }

                                CatalogLayoutPanel.Controls.Add(NewArticleCard);
                                NewArticleCard.Show();
                                NewArticleCard.Ini();
                                CatalogLayoutPanel.Invalidate();
                                Application.DoEvents();
                            }));
                        }
                        catch (ThreadAbortException) { return; }
                        catch (IOException) { return; }
                        catch (Exception ex)
                        {
                            UnityModule.DebugPrint("读取新文章属性时遇到错误：{0}", ex.Message);
                        }
                    }
                }
            }
            CatalogAdapter.Dispose();

            UnityModule.DebugPrint("======<<<目录加载完毕！>>>======");
        }

        /// <summary>
        /// 扫描本地缓存文章
        /// </summary>
        private void ScanLocalArticle()
        {
            foreach (string ArticleDirectory in Directory.GetDirectories(UnityModule.ContentDirectory))
            {
                if (CatalogLayoutPanel.Controls.Find("Article_" + Path.GetDirectoryName(ArticleDirectory), false).Length == 0)
                {
                    //加入缓存的文章
                }
            }
        }

    }
}
