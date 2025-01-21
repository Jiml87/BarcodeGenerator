using ZXing;

namespace BarcodeGenerator.Utils
{
    public static class BarcodeUtils
    {
        public static string GenerateBarcode(string inputValue, string format)
        {
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                return string.Empty;
            }

            BarcodeFormat barcodeFormat = format switch
            {
                "QR_CODE" => BarcodeFormat.QR_CODE,
                "CODE_128" => BarcodeFormat.CODE_128,
                "AZTEC" => BarcodeFormat.AZTEC,
                _ => BarcodeFormat.QR_CODE
            };

            var writer = new ZXing.BarcodeWriterSvg
            {
                Format = barcodeFormat
            };

            var svg = writer.Write(inputValue);
            return $"data:image/svg+xml;base64,{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(svg.Content))}";
        }
    }
}
