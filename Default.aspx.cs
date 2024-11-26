using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Reflection.Emit;
using Amazon.S3.Model;
using System.Collections;
using System.IO;

namespace TestYandexCloud
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AmazonS3Config configsS3 = new AmazonS3Config
            {
                ServiceURL = "https://s3.yandexcloud.net"
            };
          
            string accessKey = "KEY1";
            string secretKey = "KEY2";
            string bucketName = "garbox-fotos";
            string filePath = "";
            string objectKey = "newfilenameincloud";



            // string File_Path_Text = Path.GetDirectoryName(FileUpload1.PostedFile.FileName);
            string File_Path_Text = System.IO.Directory.GetParent(FileUpload1.PostedFile.FileName).ToString();
            string filename = Server.MapPath(FileUpload1.FileName);
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);


            Response.Write(System.IO.Path.GetPathRoot(FileUpload1.PostedFile.FileName));
            if (FileUpload1.HasFile)
            {
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[FileUpload1.PostedFile.FileName];


                    using (Stream oStream = file.InputStream)
                    {
                        using (var client = new AmazonS3Client(accessKey, secretKey, configsS3)) // Укажите соответствующий RegionEndpoint
                        {
                            var request = new PutObjectRequest
                            {
                                BucketName = bucketName,
                                Key = FileUpload1.FileName,
                                InputStream = oStream
                            };

                            var response = await client.PutObjectAsync(request);
                            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                            {
                                Response.Write("Файл успешно загружен в Yandex Cloud Object Storage Bucket!");
                            }
                            else
                            {
                                Response.Write("Произошла ошибка при загрузке файла.");
                            }
                        }
                    }

                }));

            }
            // так тоже работает, но тут с прямым путем до файла, например, C:\img\img5.jpg
            //using (AmazonS3Client client = new AmazonS3Client(accessKey, secretKey, configsS3)) // Используйте соответствующий RegionEndpoint
            //{
            //    var fileTransferUtility = new TransferUtility(client);

            //    await fileTransferUtility.UploadAsync(filename, bucketName, objectKey);
            //    Response.Write("Файл успешно загружен в Yandex Cloud Object Storage Bucket!");
            //}




        }
    }
}