using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Flatten_two_dimensional_1_2_and_3_4_gives_one_dimensional_1_2_3_4()
        {

            IEnumerable<int> output = Iterators.Flatten<int>(new[] { new[] { 1, 2 }, new[] { 3, 4 } });


            Assert.Equal(new[] { 1, 2, 3, 4 }, output);
        }

        [Fact]
        public void Filter_takes_1_2_3_4_gives_2_4()
        {

            Predicate<int> even = Iterators.Even;

            IEnumerable<int> output = Iterators.Filter(new[] { 1, 2, 3, 4 }, even);


            Assert.Equal(new[] { 2, 4 }, output);
        }

    }
}
