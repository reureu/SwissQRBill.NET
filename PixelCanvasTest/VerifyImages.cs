//
// Swiss QR Bill Generator for .NET
// Copyright (c) 2021 Manuel Bleichenbacher
// Licensed under MIT License
// https://opensource.org/licenses/MIT
//

using Codecrete.SwissQRBill.Generator;
using Docnet.Core;
using Docnet.Core.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using VerifyTests;
using VerifyXunit;

namespace Codecrete.SwissQRBill.PixelCanvasTest
{
    public class VerifyImages
    {
        static VerifyImages()
        {
            VerifyImageMagick.RegisterComparers(threshold: 0.35, ImageMagick.ErrorMetric.PerceptualHash);

            PngSettings = new VerifySettings();
            PngSettings.UseExtension("png");
            PngSettings.UseDirectory("ReferenceFiles");
        }

         protected static readonly VerifySettings PngSettings;

        public static SettingsTask VerifyPng(byte[] png, [CallerFilePath] string sourceFile = "")
        {
            return Verifier.Verify(png, PngSettings, sourceFile);
        }
    }
}