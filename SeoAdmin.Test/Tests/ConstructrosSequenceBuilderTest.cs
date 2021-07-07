using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Domain.Entities;
using Autodoc.SeoAdmin.Infrastructure.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SeoAdmin.Test.Tests
{
    [TestFixture]
    public class ConstructrosSequenceBuilderTest
    {
        //private IConstructorsSequenceBuilder _constructorsSequenceBuilder;

        [SetUp]
        public void SetUp ()
        {
            //_constructorsSequenceBuilder = new DefaultConstructorsSequenceBuilder();
        }
        [Test]
        public void IsConstructrosSequenceBuilder_CreateSequence ()
        {
            //var result = _constructorsSequenceBuilder.BuildChain();

            //Assert.IsNotNull(result, "Sequnce builder is NULL");
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryUrl ()
        {
            //var asserts = new List<string>() { "category/топливный фильтр-id333-3", "category/насос подкачки топлива-id780-3", "category/ТНВД-id331-3" };

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() { NodeName = "топливный фильтр", NodeId = 333 },
            //    new RawSeoModel() { NodeName = "насос подкачки топлива", NodeId = 780 },
            //    new RawSeoModel() { NodeName = "ТНВД", NodeId = 331 },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryMarkUrl ()
        {
            //var asserts = new List<string>() { "category/топливный фильтр-id333-3/audi-id5--2000", "category/насос подкачки топлива-id780-3/audi-id5--2000", "category/ТНВД-id331-3/audi-id5--2000" };

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() { NodeName = "топливный фильтр", NodeId = 333, MarkId = 5, MarkName = "audi" },
            //    new RawSeoModel() { NodeName = "насос подкачки топлива", NodeId = 780, MarkId = 5, MarkName = "audi" },
            //    new RawSeoModel() { NodeName = "ТНВД", NodeId = 331, MarkId = 5, MarkName = "audi" },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{                   
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryMarkSerieUrl ()
        {
            //var asserts = new List<string>()
            //{
            //    "category/топливный фильтр-id333-3/audi-id5--2000/a6 allroad-id938--2001",
            //    "category/насос подкачки топлива-id780-3/audi-id5--2000/a6 allroad-id938--2001",
            //    "category/ТНВД-id331-3/audi-id5--2000/a6 allroad-id938--2001"
            //};

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() { NodeName = "топливный фильтр", NodeId = 333, MarkId = 5, MarkName = "audi", SerieId = 938, SerieName = "a6 allroad" },
            //    new RawSeoModel() { NodeName = "насос подкачки топлива", NodeId = 780, MarkId = 5, MarkName = "audi", SerieId = 938, SerieName = "a6 allroad" },
            //    new RawSeoModel() { NodeName = "ТНВД", NodeId = 331, MarkId = 5, MarkName = "audi", SerieId = 938, SerieName = "a6 allroad" },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryMarkSerieBrandUrl ()
        {
            //var asserts = new List<string>()
            //{
            //    "category/топливный фильтр-id333-3/audi-id5--2000/a6 allroad-id938--2001/bosch-id27--1000",
            //    "category/насос подкачки топлива-id780-3/audi-id5--2000/a6 allroad-id938--2001/bosch-id27--1000",
            //    "category/ТНВД-id331-3/audi-id5--2000/a6 allroad-id938--2001/bosch-id27--1000"
            //};

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel()
            //    {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333, MarkId = 5,
            //        MarkName = "audi",
            //        SerieId = 938,
            //        SerieName = "a6 allroad",
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "насос подкачки топлива",
            //        NodeId = 780, MarkId = 5,
            //        MarkName = "audi",
            //        SerieId = 938,
            //        SerieName = "a6 allroad",
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "ТНВД",
            //        NodeId = 331,
            //        MarkId = 5,
            //        MarkName = "audi",
            //        SerieId = 938,
            //        SerieName = "a6 allroad",
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryBrandUrl ()
        {
            //var asserts = new List<string>() { "category/топливный фильтр-id333-3/bosch-id27--1000", "category/насос подкачки топлива-id780-3/bosch-id27--1000", "category/ТНВД-id331-3/bosch-id27--1000" };

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333,
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel() {
            //        NodeName = "насос подкачки топлива",
            //        NodeId = 780,
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "ТНВД",
            //        NodeId = 331,
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructCategoryMixedUrl ()
        {
            //category/toplivnyj-filtr-id333-3/audi-id5--2000/a6-id10--2001
            //var asserts = new List<string>()
            //{
            //    "category/топливный фильтр-id333-3",
            //    "category/топливный фильтр-id333-3/bosch-id27--1000",
            //    "category/топливный фильтр-id333-3/audi-id5--2000/a6 allroad-id938--2001/bosch-id27--1000",
            //    "category/топливный фильтр-id333-3/audi-id5--2000/a6 allroad-id938--2001",
            //    "category/топливный фильтр-id333-3/audi-id5--2000",
            //};

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333
            //    },
            //    new RawSeoModel() {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333,
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333, MarkId = 5,
            //        MarkName = "audi",
            //        SerieId = 938,
            //        SerieName = "a6 allroad",
            //        SupplierName = "bosch",
            //        SupplierId = 27,
            //        SupplierNodeSuffix = "1000"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333,
            //        MarkId = 5,
            //        MarkName = "audi",
            //        SerieId = 938,
            //        SerieName = "a6 allroad"
            //    },
            //    new RawSeoModel()
            //    {
            //        NodeName = "топливный фильтр",
            //        NodeId = 333,
            //        MarkId = 5,
            //        MarkName = "audi"
            //    },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();
           
            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
            //Assert.Contains(asserts[3], onlyUrls);
            //Assert.Contains(asserts[4], onlyUrls);
        }
        [Test]
        public void ConstructrosSequenceBuilder_ConstructArticleUrl ()
        {
            //колодка тормозная задняя с накладкой ГАЗ 3307(пр - во ГАЗ) -3377-0-692  Колодки тормозные барабанные ГАЗ
            //ремень зубчатый ГРМ ВАЗ 2108 (Пр-во ContiTech) -899599-0-229  Ремень ГРМ
            //масло моторное AXXIS MOTO 2T 10W-40 (Канистра 1л) -1043900-0-40 Моторное масло

            //var asserts = new List<string>()
            //{
            //    "product/колодка тормозная задняя с накладкой ГАЗ 3307(пр - во ГАЗ)-id-3377-0-692",
            //    "product/ремень зубчатый ГРМ ВАЗ 2108 (Пр-во ContiTech)-id-899599-0-229",
            //    "product/масло моторное AXXIS MOTO 2T 10W-40 (Канистра 1л)-id-1043900-0-40",
            //    "product/масло моторное AXXIS MOTO 2T 10W-40 (Канистра 1л)-id-1043900-0--1"
            //};

            //var cases = new List<RawSeoModel>()
            //{
            //    new RawSeoModel() { NodeName = "Колодки тормозные барабанные ГАЗ", NodeId = 692, ArticleName = "колодка тормозная задняя с накладкой ГАЗ 3307(пр - во ГАЗ)", ArticleId = -3377},
            //    new RawSeoModel() { NodeName = "Ремень ГРМ", NodeId = 229, ArticleName = "ремень зубчатый ГРМ ВАЗ 2108 (Пр-во ContiTech)", ArticleId = -899599 },
            //    new RawSeoModel() { NodeName = "Моторное масло", NodeId = 40, ArticleName = "масло моторное AXXIS MOTO 2T 10W-40 (Канистра 1л)", ArticleId = -1043900 },
            //    new RawSeoModel() { ArticleName = "масло моторное AXXIS MOTO 2T 10W-40 (Канистра 1л)", ArticleId = -1043900 },
            //};

            //var resList = new List<UrlCombinationModel>();

            //var constructor = _constructorsSequenceBuilder.BuildChain();

            //foreach (var item in cases)
            //{
            //    resList.AddRange(constructor.Handle(item));
            //}

            //var onlyUrls = resList.Select(i => i.UntransliteratedCombinedUrl).ToList();

            //Assert.Contains(asserts[0], onlyUrls);
            //Assert.Contains(asserts[1], onlyUrls);
            //Assert.Contains(asserts[2], onlyUrls);
            //Assert.Contains(asserts[3], onlyUrls);
        }
    }
}




