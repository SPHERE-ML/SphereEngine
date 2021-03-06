﻿//
// SensorComparer.cs
//
// Author:
//       Tom Diethe <tom.diethe@bristol.ac.uk>
//
// Copyright (c) 2015 University of Bristol
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SphereEngine.Sensors
{
    using System.Collections.Generic;

    /// <summary>
    /// The sensor comparer.
    /// </summary>
    internal class SensorComparer : IComparer<ISensor>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(ISensor x, ISensor y)
        {
            int i1 = string.CompareOrdinal(x.Name, y.Name);
            int i2 = string.CompareOrdinal(x.Id, y.Id);
            return (1000 * i1) + i2;
        }

        #endregion
    }

    /// <summary>
    /// Sensor bucket comparer.
    /// </summary>
    internal class SensorBucketComparer : IComparer<SensorBucket>
    {
        /// <summary>
        /// Compare the specified x and y.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public int Compare(SensorBucket x, SensorBucket y)
        {
            int i1 = string.CompareOrdinal(x.Sensor.Name, y.Sensor.Name);
            int i2 = string.CompareOrdinal(x.Sensor.Id, y.Sensor.Id);
            // int i3 = string.CompareOrdinal(x.Name, y.Name);
            // int i3 = x.Index < y.Index ? -1 : x.Index > y.Index ? 1 : 0;
            int i3 = x.Index - y.Index;
            return ((1000000 * i1) + 1000 * i2) + i3;
        }
    }
}