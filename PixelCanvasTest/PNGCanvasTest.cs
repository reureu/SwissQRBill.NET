﻿//
// Swiss QR Bill Generator for .NET
// Copyright (c) 2018 Manuel Bleichenbacher
// Licensed under MIT License
// https://opensource.org/licenses/MIT
//

using Codecrete.SwissQRBill.Generator;
using Codecrete.SwissQRBill.PixelCanvas;
using System.IO;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace Codecrete.SwissQRBill.PixelCanvasTest
{
    [UsesVerify]
    public class PNGCanvasTest
    {
        [Fact]
        public Task PngBillQrBill()
        {
            Bill bill = SampleData.CreateExample1();

            byte[] png;
            using (PNGCanvas canvas = new PNGCanvas(QRBill.QrBillWidth, QRBill.QrBillHeight, 300, "\"Liberation Sans\",Arial, Helvetica"))
            {
                bill.Format.OutputSize = OutputSize.QrBillOnly;
                QRBill.Draw(bill, canvas);
                png = canvas.ToByteArray();
            }

            return VerifyImages.VerifyPng(png);
        }

        [Fact]
        public Task PngBillA4()
        {
            Bill bill = SampleData.CreateExample3();
            byte[] png;
            using (PNGCanvas canvas =
                new PNGCanvas(QRBill.A4PortraitWidth, QRBill.A4PortraitHeight, 144, "Arial,\"Liberation Sans\",Helvetica"))
            {
                bill.Format.OutputSize = OutputSize.A4PortraitSheet;
                QRBill.Draw(bill, canvas);
                png = canvas.ToByteArray();
            }

            return VerifyImages.VerifyPng(png);
        }

        [Fact]
        public void PngWriteTo()
        {
            Bill bill = SampleData.CreateExample5();
            using PNGCanvas canvas =
                new PNGCanvas(QRBill.A4PortraitWidth, QRBill.A4PortraitHeight, 144, "Helvetica, Arial, \"Liberation Sans\"");
            QRBill.Draw(bill, canvas);
            MemoryStream ms = new MemoryStream();
            canvas.WriteTo(ms);
        }

        [Fact]
        public void PngSaveAs()
        {
            Bill bill = SampleData.CreateExample6();
            using PNGCanvas canvas =
                new PNGCanvas(QRBill.QrBillWidth, QRBill.QrBillHeight, 144, "Helvetica, Arial, \"Liberation Sans\"");
            QRBill.Draw(bill, canvas);
            canvas.SaveAs("qrbill.png");
        }

    }
}