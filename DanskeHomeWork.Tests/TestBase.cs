using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DanskeHomeWork.Tests
{
    public class TestBase
    {
        internal Random Randomizer = new Random(DateTime.Now.Millisecond);
    }
}
