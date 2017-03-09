using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageUpload
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuUpload.HasFile) {
                if ((fuUpload.PostedFile.ContentType == "image/jpeg") || (fuUpload.PostedFile.ContentType == "image/png") || (fuUpload.PostedFile.ContentType == "image/bmp") || (fuUpload.PostedFile.ContentType == "image/gif"))
                {
                    if (Convert.ToInt64(fuUpload.PostedFile.ContentLength) < 1000000)
                    {
                        string photoFolder = Path.Combine(@"C:\Users\Victorious\Documents\Visual Studio 2010\Projects\ImageUpload\ImageUpload\Photos\", "user1"); //User.Identity.Name
                        if (!Directory.Exists(photoFolder))
                        {
                            Directory.CreateDirectory(photoFolder);
                        }
                        string extension = Path.GetExtension(fuUpload.FileName);
                        string uniqueFileName = Path.ChangeExtension(fuUpload.FileName, DateTime.Now.Ticks.ToString());
                        fuUpload.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));

                        DisplayUploadedPhotos(photoFolder);

                        lblStatus.Text = "<font color='Green'>Successfully uploaded"+fuUpload.FileName+"</font>";
                    }
                    else
                    {
                        lblStatus.Text = "File size must be less than 10MB";
                    }
                }
                else {
                    lblStatus.Text = "File must be of jpeg, png, bmp or gif type";
                }
            }
            else
            {
                lblStatus.Text = "No file selected";
            }

        }

        public void DisplayUploadedPhotos(string folder) {
            string[] allPhotoFiles = Directory.GetFiles(folder);
            IList<string> allPhotoPaths = new List<string>();
            string filename;
            foreach (string f in allPhotoFiles) {
                filename = Path.GetFileName(f);
                allPhotoPaths.Add(@"C:\Users\Victorious\Documents\Visual Studio 2010\Projects\ImageUpload\ImageUpload\Photos\user1\" + filename); //User.Identity.Name
                rptrUserPhoto.DataSource = allPhotoPaths;
                rptrUserPhoto.DataBind();
            }
        }
    }
}
