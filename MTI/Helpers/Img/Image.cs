using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MTI.ViewModel;
using System.Data.Entity.Validation;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace MTI.Helpers.Img
{
    public class Image
    {
        public bool insertimage(StudentViewModel student)
        {

            if (IsValid(student.students.ImageFile))
            {
                String filename = Path.GetFileNameWithoutExtension(student.students.ImageFile.FileName.ToString());
                string extension = Path.GetExtension(student.students.ImageFile.FileName);
              
                //check if folder exist
                var folder = HttpContext.Current.Server.MapPath("~/Image/" + student.students.batchid + "/" + student.students.Katiba + "/" + student.students.saria + "/" + student.students.Fasila + "/" + student.students.StudentNumber + "/");
                if (!Directory.Exists(folder))
                {
                    //create folder
                    Directory.CreateDirectory(folder);
                }

                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                student.students.Image = "/Image/" + student.students.batchid + "/" + student.students.Katiba + "/" + student.students.saria + "/" + student.students.Fasila + "/" + student.students.StudentNumber + "/" + filename;
                filename = Path.Combine(HttpContext.Current.Server.MapPath("/Image/" +student.students.batchid + "/" + student.students.Katiba + "/" + student.students.saria + "/" + student.students.Fasila + "/" + student.students.StudentNumber + "/"), filename);
                student.students.ImageFile.SaveAs(filename);
                return true;
            }

            return false;
        }

        public bool IsValid(object value)
        {
            bool isValid = false;
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength > 1 * 6000 * 6000)
            {
                return isValid;
            }

            if (IsFileTypeValid(file))
            {
                isValid = true;
            }
            return isValid;
        }

        private bool IsFileTypeValid(HttpPostedFileBase file)
        {
            //bool isValid = false;
           bool isValid = true;

            /*   try
               {
                   using (var img = System.Drawing.Image.FromStream(file.InputStream))
                   {
                       if (IsOneOfValidFormats(img.RawFormat))
                       {
                           isValid = true;
                       }
                   }
               }
               catch
               {
                   //Image is invalid
               }*/
            return isValid;
        }
/*
        private bool IsOneOfValidFormats(ImageFormat rawFormat)
        {
            List<ImageFormat> formats = getValidFormats();

            foreach (ImageFormat format in formats)
            {
                if (rawFormat.Equals(format))
                {
                    return true;
                }
            }
            return false;
        }
        */
        private List<ImageFormat> getValidFormats()
        {
            List<ImageFormat> formats = new List<ImageFormat>();
            formats.Add(ImageFormat.Png);
            formats.Add(ImageFormat.Jpeg);
            formats.Add(ImageFormat.Tiff);
            return formats;
        }


    }
}