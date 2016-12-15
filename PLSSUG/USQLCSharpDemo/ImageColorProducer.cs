﻿using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using USQLCSharpDemo.Utils;

namespace USQLCSharpDemo
{
    public class ImageColorProducer : IProcessor
    {
        private readonly int _topColorCount;

        public ImageColorProducer(int topColorCount)
        {
            _topColorCount = topColorCount;
        }

        public override IRow Process(IRow input, IUpdatableRow output)
        {
            var imgContent = input.Get<byte[]>("content");
            var colorList = input.Get<SqlMap<int, string>>("colors");
            using (var ms = new MemoryStream(imgContent))
            {
                var bMap = Image.FromStream(ms) as Bitmap;
                var result = ColorExtractor.GetMostUsedColor(bMap, _topColorCount);
                if (result.Any())
                {
                    colorList = new SqlMap<int, string>(result);
                }
            }
            output.Set("colors", colorList);
            return output.AsReadOnly();
        }
    }
}
