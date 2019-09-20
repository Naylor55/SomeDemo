/********************************************************************
* Copyright (c) 2019 ALL Rights Reserved.
* CLR版本：4.0.30319.42000
* 机器名称：NAYLOR
* 公司名称：
* 命名空间：ConsoleApplication
* 文件名： Tool
* 版本号： V1.0.0.0
* 唯一标识： 70e5c4d1-d910-42c2-bf6c-8790ed617981
* 当前的用户域： NAYLOR
* 创建人： Cnayl
* 电子邮箱： cnaylor@163.com
* 创建时间： 2019/8/16 17:41:24

* 描述：
*
* ==================================================================
* 修改标记
* 修改时间： 2019/8/16 17:41:24
* 修改人： Cnayl
* 版本号： 
* 描述：
*
*
********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Tool
    {
        public static List<string> ReadTextFileToList(string filePath)
        {
            List<string> list = new List<string>();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                //使用StreamReader类来读取文件 
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string tmp = sr.ReadLine();
                while (tmp != null)
                {
                    list.Add(tmp);
                    tmp = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {

            }
            return list;
        }

        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="dicList">索引库词典</param>
        /// <returns>和索引库词典匹配的集合</returns>
        public static List<string> FindSearchWords(string keyword, ref List<string> dicList)
        {
            if (dicList == null || dicList.Count == 0)
            {
                return new List<string>();
            }
            List<string> words = new List<string>();
            List<string> cutWords = new List<string>();
            //去掉换行、空格、制表符、回车
            keyword = keyword.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            //若关键字长度为1，不分词
            if (keyword.Length == 1)
            {
                words.Add(keyword);
            }
            else if (keyword.Length > 1)
            {
                //分词  cutLength：为切割长度；point：为切割起始位置。默认从 0 处开始切割，切割的最小长度为 2 。
                int length = keyword.Length;
                for (int cutLength = 2; cutLength <= length; cutLength++)
                {
                    for (int point = 0; point <= length - 2; point++)
                    {
                        if (length - point >= cutLength)
                        {
                            string word = keyword.Substring(point, cutLength);
                            Console.WriteLine("切割到的词：" + word);
                            cutWords.Add(word);
                            if (dicList.Contains(word))
                            {
                                words.Add(word);
                            }
                        }
                    }
                }
            }
            if (words.Count == 0)
            {
                words = words.Concat(cutWords).ToList();
            }
            //去重
            words = words.Distinct().ToList();
            return words;
        }

    }
}
