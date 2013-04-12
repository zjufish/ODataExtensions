﻿using System;
using Jesko.ODataExtensions.Tests.Pocos;
using NUnit.Framework;

namespace Jesko.ODataExtensions.Tests
{
    [TestFixture]
    public class OrderByTests
    {
        [Test]
        public void OrderBy_Generates_Order_OData()
        {
            var instance = new ClassWithProperties();

            var actual = instance.OrderBy(x => x.StringProperty);

            Assert.AreEqual("$orderby=(StringProperty asc)", actual.ToString());
        }
        
        [Test]
        public void OrderBy_Can_Order_Descending()
        {
            var instance = new ClassWithProperties();

            var actual = instance.OrderBy(x => x.StringProperty, OrderBy.Descending);

            Assert.AreEqual("$orderby=(StringProperty desc)", actual.ToString());
        }

        [Test]
        public void OrderBy_Works_On_Types_Other_Than_InstanceType()
        {
            var instance = new OtherClass();

            var actual = instance.OrderBy<ClassWithProperties>(x => x.StringProperty, OrderBy.Descending);

            Assert.AreEqual("$orderby=(StringProperty desc)", actual.ToString());
        }

        [Test]
        public void OrderBy_Throws_ArgumentException_When_Expression_Not_A_Member()
        {
            var instance = new ClassWithProperties();

            Assert.Throws<ArgumentException>(() => instance.OrderBy(x => "foo"));
        }
    }
}