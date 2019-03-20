using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace 代发工资.Controllers
{
    public class UploadsController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();

        }

        //接收ajax提交的数据，并保存文件到服务器上
        [HttpPost]
        public string AjaxSaveAs(HttpPostedFileBase MyFile)
        {
            //得到的名字是文件在本地机器的绝对路径
            var strLocalFullPathName = MyFile.FileName;
            //提取出单独的文件名，不需要路径
            var strFileName = Path.GetFileName(strLocalFullPathName);
            //定义服务器的文件夹，用来保存文件
            var strServerFilePath = Server.MapPath("~/Upload/");
            //将接收到文件保存在服务器指定上当
            MyFile.SaveAs(Path.Combine(strServerFilePath, strFileName));

            return "upload done from server!";

        }
        [HttpPost]
        public ActionResult SaveAs(HttpPostedFileBase MyFile)
        {
            //得到的名字是文件在本地机器的绝对路径
            var strLocalFullPathName = MyFile.FileName;
            //提取出单独的文件名，不需要路径
            var strFileName = Path.GetFileName(strLocalFullPathName);
            //定义服务器的文件夹，用来保存文件
            var strServerFilePath = Server.MapPath("~/Upload/");
            //将接收到文件保存在服务器指定上当
            MyFile.SaveAs(Path.Combine(strServerFilePath, strFileName));

            //下面只是用来显示一些相关字符串做测试用
            ViewBag.strLocalFullPathName = strLocalFullPathName;
            ViewBag.strFileName = strFileName;
            ViewBag.strServerFilePath = strServerFilePath;

            return View("~/Views/Uploads/UploadSuccess.cshtml");

        }

        public ActionResult Views()
        {
            return View();
        }
    }
}