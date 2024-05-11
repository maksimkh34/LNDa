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
            // Если файл нужно сохранить, сохраняем и открываем в проводнике папку с сохраненным файлом. Если открыть, то сохраняем без диалогов по временному пути и потом удаляем
            // Тут нужно написать реализацию этого (сохранение файла или его открытие)



            // В конце нужно сбросить на Ignore
            incomingFileDialogResult = IncomingFileDialogResult.Ignore;
        }
    }
}
