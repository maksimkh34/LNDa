using System;
using System.Collections.Generic;
using System.Text;
using static LNDa.App;

namespace LNDa
{
    internal static class FileHandlerClass
    {
        internal static void FileHandler(string fileName, string data) {
            new IncomingFileDialog().ShowDialog();
            // После того, как отработает IncomingFileDialog, в incomingFileDialogResult будет лежать какое-либо значение (что нужно сделать с файлом)
            //
            // Тут нужно написать реализацию этого (сохранение файла или его открытие)



            // В конце нужно сбросить на Ignore
            incomingFileDialogResult = IncomingFileDialogResult.Ignore;
        }
    }
}
