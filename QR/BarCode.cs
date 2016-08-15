using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Features2D;

namespace QR
{
    class BarCode
    {
        public Bitmap GenerateQRCode(string contents, PictureBox qrimage, string codeType, string codeColor, string erroCorrectionLevel, bool isShowCode = false)
        {
            if (contents == string.Empty)
            {
                MessageBox.Show("invalid input");               
                return null;
            }

            if(codeColor == null)
            {
                codeColor = "Black";
            }

            BarcodeWriter writer = new BarcodeWriter();

            //赋值为什么要用逗号？
            var encOptions = new ZXing.Common.EncodingOptions
            {
                Width = qrimage.Width,
                Height = qrimage.Height,
                Margin = 0,
                PureBarcode = false
            };

            switch(erroCorrectionLevel)
            {
                case "L":
                    encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L);
                    break;
                case "M":
                    encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.M);
                    break;
                case "Q":
                    encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.Q);
                    break;
                case "H":
                    encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                    break;
                default:
                    encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                    break;
            }
            
            encOptions.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");

            writer.Renderer = new BitmapRenderer()
            {
                Foreground = Color.FromName(codeColor)
            };

            writer.Options = encOptions;

            switch (codeType)
            {
                case "CODE_128":
                    writer.Format = ZXing.BarcodeFormat.CODE_128;
                    break;
                case "QR_CODE":
                    writer.Format = ZXing.BarcodeFormat.QR_CODE;
                    break;
                case "PDF_417":
                    writer.Format = ZXing.BarcodeFormat.PDF_417;
                    break;
                default:
                    writer.Format = ZXing.BarcodeFormat.QR_CODE;
                    break;
            }          

            Bitmap bitmap = writer.Write(contents);
            if (isShowCode == true)
            {
                qrimage.Image = bitmap;
            }

            return bitmap;
        }


        public void SaveQRCode(PictureBox qrimage)
        {
            bool isSaved = true;
            Bitmap bitmap = (Bitmap)qrimage.Image;

            if(bitmap == null)
            {
                MessageBox.Show("Please input the contents");
                return;
            }
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.Title = "Choose the directory to save the QRCode";
            //这个枚举的格式？
            saveImage.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";
            saveImage.ShowHelp = true;
            if(saveImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImage.FileName;
                if(fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1);
                    System.Drawing.Imaging.ImageFormat imageformat = null;
                    if(fileExtName != "")
                    {
                        switch(fileExtName)
                        {
                            case "jpg":
                                imageformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "png":
                                imageformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case "gif":
                                imageformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            case "bmp":
                                imageformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            default:
                                MessageBox.Show("You can only save as jpg, png, gif format");
                                isSaved = false;
                                break;
                        }
                    }
                    
                    if(imageformat == null)
                    {
                        imageformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }
                    
                    if(isSaved)
                    {
                        //这里的try和catch什么意思？
                        try
                        {
                            bitmap.Save(fileName, imageformat);
                            MessageBox.Show("QRCode has been saved successfully");
                        }
                        catch
                        {
                            MessageBox.Show("Failed to save QRCode");
                        }
                    }
                }
            }
        }

        public void DecodeQRCode(PictureBox qrimage, PictureBox processedimage, PictureBox processedimage2, TextBox resultContents, string path)
        {
            if (path != null)
            {
                System.Drawing.Image img = Image.FromFile(path, false);
                img = img.GetThumbnailImage(qrimage.Width, qrimage.Height, null, IntPtr.Zero);
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(path, false);
                qrimage.Image = img;
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode(bitmap);
                resultContents.Text = result.Text;
            }
            else
            {
                OpenFileDialog openImage = new OpenFileDialog();
                openImage.Title = "Open a QRCode image";
                openImage.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";
                openImage.RestoreDirectory = true;
                openImage.ShowHelp = true;

                if (openImage.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image img = Image.FromFile(openImage.FileName, false);
                    img = img.GetThumbnailImage(qrimage.Width, qrimage.Height, null, IntPtr.Zero);
                    //Bitmap bitmap = (Bitmap)Bitmap.FromFile(openImage.FileName, false);
                    Bitmap bitmap = new Bitmap(img);

                    Image<Bgr, Byte> imgsource = new Image<Bgr, byte>(bitmap);

                    //灰度图像
                    Image<Gray, Byte> grayimg = imgsource.Convert<Gray, Byte>();

                    //高斯滤波
                    Image<Gray, Byte> imgSmooth = grayimg.SmoothGaussian(3);
                    
                    //二值化
                    Image<Gray, Byte> imgThr = imgSmooth.ThresholdBinary(new Gray(100), new Gray(255));

                    //腐蚀
                    Image<Gray, Byte> imgErode = imgThr.Erode(5);
                    //CvInvoke.Imshow("", imgErode);

                    //Canny算子，提取轮廓
                    Image<Gray, Byte> imgCanny = imgErode.Canny(100, 200);
                    //Image<Gray, Byte> imgCanny = imgErode.Canny(otsu_val*0.5, otsu_val);
                    //CvInvoke.Imshow("", imgCanny);

                    //原始图片
                    Mat img0 = CvInvoke.Imread(openImage.FileName, Emgu.CV.CvEnum.LoadImageType.Grayscale);
                    //Mat img0 = new Mat(openImage.FileName, LoadImageType.Grayscale);
                    CvInvoke.Resize(img0, img0, new Size(processedimage.Width, processedimage.Height));
                    //CvInvoke.Imshow("", img0);

                    //寻找轮廓                
                    VectorOfVectorOfPoint contoursDetected = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(imgCanny, contoursDetected, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

                    //遮罩
                    Mat mask = new Mat(img0.Width, img0.Height, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    mask.SetTo(new MCvScalar(0));

                    CvInvoke.DrawContours(mask, contoursDetected, -1, new MCvScalar(255), -1);
                    //CvInvoke.Imshow("mask", mask);

                    Mat crop = new Mat(img0.Rows, img0.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    crop.SetTo(new MCvScalar(255));

                    img0.CopyTo(crop, mask);

                    CvInvoke.Normalize(mask.Clone(), mask, 0.0, 255.0, NormType.MinMax, DepthType.Cv8U);
                    //CvInvoke.Imshow("cropped", crop);
                    processedimage.Image = crop.Bitmap;

                    //Point[][] con1 = contoursDetected.ToArrayOfArray();
                    //PointF[][] con2 = Array.ConvertAll<Point[], PointF[]>(con1, new Converter<Point[], PointF[]>(PointToPointF));

                    //最小矩形匹配
                    RotatedRect rect = new RotatedRect();
                    for (int i = 0; i < contoursDetected.Size; ++i)
                    {
                        rect = CvInvoke.MinAreaRect(contoursDetected[i]);
                    }

                    grayimg.Draw(rect, new Gray(50), 2);
                    //rect通过center，angle， size可以计算出坐标

                    //旋转矫正
                    float angle = rect.Angle;
                    SizeF rect_size = rect.Size;
                    if (rect.Angle < -45F)
                    {
                        angle += 90F;
                        float temp = rect_size.Width;
                        rect_size.Width = rect_size.Height;
                        rect_size.Height = temp;
                    }

                    Mat M = new Mat();
                    Mat rotated = new Mat();
                    Mat cropped = new Mat();
                    CvInvoke.GetRotationMatrix2D(rect.Center, angle, 1.0, M);
                    CvInvoke.WarpAffine(img0, rotated, M, img0.Size, Inter.Cubic);
                    CvInvoke.GetRectSubPix(rotated, rect_size.ToSize(), rect.Center, cropped);
                    processedimage2.Image = cropped.Bitmap;



                    int skipRows = 3;
                    int[] stateCount = new int[5] { 0, 0, 0, 0, 0 };
                    int currentState = 0;
                    int counter = 0;
                    //float[,] arr = new float[cropped.Width, cropped.Height];
                    //cropped.CopyTo(arr);

                    Image<Gray, Byte> arr = cropped.ToImage<Gray, Byte>();
                    arr = arr.ThresholdBinary(new Gray(80), new Gray(255));
                    //CvInvoke.Imshow("", arr);


                    /*for (int rows = 0; rows < arr.Rows; rows += skipRows)
                    {
                        stateCount[0] = 0;
                        stateCount[1] = 0;
                        stateCount[2] = 0;
                        stateCount[3] = 0;
                        stateCount[4] = 0;
                        currentState = 0;

                        for (int col = 0; col < arr.Cols; col++)
                        {

                            if (arr[rows, col].Intensity < 128)
                            {
                                // We're at a black pixel
                                if ((currentState & 0x1) == 1)
                                {
                                    // We were counting white pixels
                                    // So change the state now

                                    // W->B transition
                                    currentState++;
                                }

                                // Works for boths W->B and B->B
                                stateCount[currentState]++;
                            }
                            else
                            {
                                // We got to a white pixel...
                                if ((currentState & 0x1) == 1)
                                {
                                    // W->W change
                                    stateCount[currentState]++;
                                }
                                else
                                {
                                    // ...but, we were counting black pixels
                                    if (currentState == 4)
                                    {
                                        // We found the 'white' area AFTER the finder patter
                                        // Do processing for it here
                                        if (checkRatio(stateCount))
                                        {
                                            //MessageBox.Show(rows.ToString(), col.ToString());
                                            arr.Draw(new Rectangle(rows - 5, col - 7, 15, 15), new Gray(120), 2);
                                            // This is where we do some more checks
                                        }
                                        else
                                        {
                                            currentState = 3;
                                            stateCount[0] = stateCount[2];
                                            stateCount[1] = stateCount[3];
                                            stateCount[2] = stateCount[4];
                                            stateCount[3] = 1;
                                            stateCount[4] = 0;
                                            continue;
                                        }
                                        currentState = 0;
                                        stateCount[0] = 0;
                                        stateCount[1] = 0;
                                        stateCount[2] = 0;
                                        stateCount[3] = 0;
                                        stateCount[4] = 0;
                                    }
                                    else
                                    {
                                        // We still haven't go 'out' of the finder pattern yet
                                        // So increment the state
                                        // B->W transition
                                        currentState++;
                                        stateCount[currentState]++;
                                    }
                                }
                            }
                        }
                    }*/

                    List<VectorOfPoint> contoursArray = new List<VectorOfPoint>();
                    int count1 = contoursDetected.Size;
                    for (int i = 0; i < count1; i++)
                    {
                        using (VectorOfPoint currContour = contoursDetected[i])
                        {
                            contoursArray.Add(currContour);
                        }
                    }

                    //0 1矩阵
                    byte[] imageBytes = arr.Bytes;
                    var binary_0_Or_255 = from byteInt in imageBytes select byteInt / 255;
                    //convert to array
                    int[] arrayOnlyOneOrZero = binary_0_Or_255.ToArray();
                    //checking the array content

                    string resultmatrix = string.Join("", arrayOnlyOneOrZero);
                    int count = resultmatrix.IndexOf('0');
                    //MessageBox.Show(count.ToString());


                    qrimage.Image = img;
                    if (count > 20)
                    {
                        BarcodeReader reader = new BarcodeReader();
                        Result result = reader.Decode(bitmap);
                        resultContents.Text = result.Text;
                        //resultContents.Text = resultmatrix;
                    }
                    else
                    {
                        BarcodeReader reader = new BarcodeReader();
                        Result result = reader.Decode(cropped.Bitmap);
                        resultContents.Text = "unable to read";

                   
                    }
                }
            }
        }

        public void CombineQRCode(string contents, PictureBox qrimage, string codeType, string codeColor, string erroCorrectionLevel)
        {
            Bitmap bitmap = GenerateQRCode(contents, qrimage, codeType, codeColor, erroCorrectionLevel, false);
            
            if(bitmap == null)
            {
                return;
            }

            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Title = "Open a logo image";
            openImage.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";
            openImage.RestoreDirectory = true;
            openImage.ShowHelp = true;

            if (openImage.ShowDialog() == DialogResult.OK)
            {       
                System.Drawing.Image logo = System.Drawing.Image.FromFile(openImage.FileName);
                logo = logo.GetThumbnailImage(logo.Width / 3, logo.Height / 3, null, IntPtr.Zero);

                int left = (bitmap.Width / 2) - (logo.Width / 2);
                int top = (bitmap.Height / 2) - (logo.Height / 2);

                Graphics bindedImg = Graphics.FromImage(bitmap);
                bindedImg.DrawImage(logo, new Point(left, top));

                qrimage.Image = bitmap;
            }
        }

    }
}