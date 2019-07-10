using NPOI.HSSF.UserModel;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDotNetMvc.Controllers
{
    public class ExcelImportController : BaseController
    {


        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 导入 Excel 通过数据库连接的方式
        /// </summary>
        /// <param name="fileBase"></param>
        /// <returns></returns>
        public ActionResult DoExcelImportInDatabaseWay(HttpPostedFileBase fileBase)
        {
            HttpPostedFileBase file = Request.Files["files"];
            string FileName;
            string savePath;
            if (file == null || file.ContentLength <= 0)
            {
                ViewBag.error = "文件不能为空";
                return View();
            }
            else
            {
                string filename = Path.GetFileName(file.FileName);
                int filesize = file.ContentLength;//获取上传文件的大小单位为字节byte
                string fileEx = System.IO.Path.GetExtension(filename);//获取上传文件的扩展名
                string NoFileName = System.IO.Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
                int Maxsize = 4000 * 1024;//定义上传文件的最大空间大小为4M
                string FileType = ".xls,.xlsx";//定义上传文件的类型字符串
                FileName = NoFileName + DateTime.Now.ToString("yyyyMMddhhmmss") + fileEx;
                if (!FileType.Contains(fileEx))
                {
                    ViewBag.error = "文件类型不对，只能导入xls和xlsx格式的文件";
                    return View();
                }
                if (filesize >= Maxsize)
                {
                    ViewBag.error = "上传文件超过4M，不能上传";
                    return View();
                }
                string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excel/";
                savePath = Path.Combine(path, FileName);
                file.SaveAs(savePath);
            }
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + savePath + ";" + "Extended Properties=Excel 8.0";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter("select * from [Sheet1$]", strConn);
            DataSet myDataSet = new DataSet();
            try
            {
                myCommand.Fill(myDataSet, "ExcelInfo");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            DataTable table = myDataSet.Tables["ExcelInfo"].DefaultView.ToTable();
            return null;
        }

        /// <summary>
        /// 导入 Excel 通过 NPOI
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelImportInNPOIWay(HttpPostedFileBase fileBase)
        {
            string FileName;
            string savePath;
            HttpPostedFileBase file = Request.Files["files"];
            string filename = Path.GetFileName(file.FileName);
            int filesize = file.ContentLength;//获取上传文件的大小单位为字节byte
            string fileEx = System.IO.Path.GetExtension(filename);//获取上传文件的扩展名
            string NoFileName = System.IO.Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
            int Maxsize = 4000 * 1024;//定义上传文件的最大空间大小为4M
            string FileType = ".xls,.xlsx";//定义上传文件的类型字符串
            FileName = NoFileName + DateTime.Now.ToString("yyyyMMddhhmmss") + fileEx;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excel/";
            savePath = Path.Combine(path, FileName);
            file.SaveAs(savePath);
            DataTable dt = ImportExcelFile(savePath);
            return null;
        }

        public DataTable ImportExcelFile(string filePath)
        {
            HSSFWorkbook hssfworkbook;

            #region//初始化信息  
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion

            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }
            while (rows.MoveNext())
            {
                HSSFRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


    }
}
