using System;
using _3DConverter;
using _3DConverter.Converter;
using _3DConverter.Converter.ConvertibleFiles;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace UnitTests
{
    public class ConvertibleFileTest
    {
        [Theory]
        [AutoData]
        public void ObjConvertibleFile_ShouldHaveRightName(string fileName, byte[] result, string fileOriginalPath)
        {
            //Arrange
            var fileNameFullPath = fileName + ".shapr";
            var objConvertibleFile =
                new ObjConvertibleFile(new ImportedFileModel(fileNameFullPath, result, fileOriginalPath));
            //Act
            //Assert
            objConvertibleFile.FileName.Should().EndWith(".obj");
        }

        [Theory]
        [AutoData]
        public void StlConvertibleFile_ShouldHaveRightName(string fileName, byte[] result, string fileOriginalPath)
        {
            //Arrange
            var fileNameFullPath = fileName + ".shapr";
            var objConvertibleFile =
                new StlConvertibleFile(new ImportedFileModel(fileNameFullPath, result, fileOriginalPath));
            //Act
            //Assert
            objConvertibleFile.FileName.Should().EndWith(".stl");
        }

        [Theory]
        [AutoData]
        public void ConvertibleFileBase_ShouldHaveRightFileOriginalPath(string fileName, byte[] result,
            string fileOriginalPath)
        {
            //Arrange
            var objConvertibleFile = new StepConvertibleFile(new ImportedFileModel(fileName, result, fileOriginalPath));
            //Act
            //Assert
            objConvertibleFile.FileOriginalPath.Should().Be(fileOriginalPath);
        }

        [Theory]
        [AutoData]
        public void StepConvertibleFile_ShouldHaveRightName(string fileName, byte[] result, string fileOriginalPath)
        {
            //Arrange
            var fileNameFullPath = fileName + ".shapr";
            var objConvertibleFile =
                new StepConvertibleFile(new ImportedFileModel(fileNameFullPath, result, fileOriginalPath));
            //Act
            //Assert
            objConvertibleFile.FileName.Should().EndWith(".step");
        }

        [Theory]
        [AutoData]
        public void ConvertibleFileBase_ShouldChangeImportedFileProcessStateStart(string fileName, byte[] result,
            string fileOriginalPath)
        {
            //Arrange
            var fileModel = new ImportedFileModel(fileName, result, fileOriginalPath);
            var objConvertibleFile = new StepConvertibleFile(fileModel);

            //Act
            objConvertibleFile.Convert();

            //Assert
            fileModel.ConvertProcessType.Should().Be(ConvertProcessType.Start);
        }

        [Theory]
        [AutoData]
        public void ConvertibleFileBase_ShouldChangeImportedFileProcessStateCancel(string fileName, byte[] result,
            string fileOriginalPath)
        {
            //Arrange
            var fileModel = new ImportedFileModel(fileName, result, fileOriginalPath);
            var objConvertibleFile = new StepConvertibleFile(fileModel);

            //Act
            objConvertibleFile.DeleteFile();

            //Assert
            fileModel.ConvertProcessType.Should().Be(ConvertProcessType.Cancel);
        }
    }
}