using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerSkyLite_CS.Controller
{
    static public class FileController
    {
        /// <summary>
        /// 格式化字节大小
        /// </summary>
        /// <param name="ByteCount">比特总数</param>
        /// <returns></returns>
        static public string FormatSize(ulong ByteCount)
        {
            string Result = "";
            if (ByteCount < 1024)
                Result = (ByteCount + " Byte");
            else if (ByteCount < 1048576)
                Result = string.Format("{0} KB", ByteCount >> 10);
            else if (ByteCount < 1073741824)
                Result = string.Format("{0} MB", ByteCount >> 20);
            else if (ByteCount < 1099511627776)
                Result = string.Format("{0} GB", ByteCount >> 30);
            else
                Result = string.Format("{0} TB", ByteCount >> 40);
            UnityModule.DebugPrint("格式化文件大小：{0} => {1}",ByteCount.ToString(),Result);
            return Result;
        }

        /// <summary>
        /// 读取文件大小
        /// </summary>
        /// <returns>文件大小</returns>
        static public string GetFileSize(string FilePath)
        {
            UnityModule.DebugPrint("获取文件大小：{0}",FilePath);
            try
            {
                return FormatSize(Convert.ToUInt64(new FileInfo(FilePath).Length));
            } catch 
            {
                return "(未知大小)";
            }
        }

        /// <summary>
        /// 安全的合并路径
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        static public string PathCombine(string DirectoryPath, string FileName)
        {
            UnityModule.DebugPrint("合并文件路径：\"{0}\" + \"{1}\"",DirectoryPath,FileName);
            if (!DirectoryPath.EndsWith("\\")) DirectoryPath += "\\";
            return (DirectoryPath + FileName).Replace("\\\\", "\\");
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="SourcesPath">源文件路径</param>
        /// <param name="TargetPath">目标文件路径</param>
        static public void CopyFile(string SourcesPath, string TargetPath, bool OverWrite, bool ThrowException)
        {
            UnityModule.DebugPrint("复制文件 \"{0}\" 至 \"{1}\"，{2}允许复写，{3}允许抛出异常 ", SourcesPath, TargetPath, OverWrite ? "" : "不", ThrowException ? "" : "不");
            try
            {
                File.Copy(SourcesPath, TargetPath, OverWrite);
            }
            catch (Exception CopyException)
            {
                if (ThrowException) throw CopyException;
            }
        }

    }
}
