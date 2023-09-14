using Material.Icons;
using System.Collections.Generic;

namespace DragToDo.Helpers;

public static class FileTypeIconExtension
{
    public static IDictionary<string, MaterialIconKind> FILE_TYPE_ICON = new Dictionary<string, MaterialIconKind>()
    {
        { "XLS", MaterialIconKind.MicrosoftExcel },
        { "XLSX", MaterialIconKind.MicrosoftExcel },
        { "DOC", MaterialIconKind.MicrosoftWord},
        { "DOCX", MaterialIconKind.MicrosoftWord},
        { "PPT", MaterialIconKind.MicrosoftPowerpoint},
        { "PPTX", MaterialIconKind.MicrosoftPowerpoint},

        { "PDF", MaterialIconKind.FilePdfBox},
        { "TXT", MaterialIconKind.FormatText},
        { "JPG", MaterialIconKind.FileJpgBox},
        { "PNG", MaterialIconKind.FilePngBox},

        { "MP4", MaterialIconKind.FileVideo},

    };

    public static MaterialIconKind GetIcon(this string fullFileName)
    {
        var parts = fullFileName.Trim().Split('.');
        var suffix = parts[parts.Length - 1].ToUpper();
        if (FILE_TYPE_ICON.ContainsKey(suffix))
        {
            return FILE_TYPE_ICON[suffix];
        }
        return MaterialIconKind.File;
    }
}
