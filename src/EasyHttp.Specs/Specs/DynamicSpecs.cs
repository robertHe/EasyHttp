#region License
// Distributed under the BSD License
// =================================
//
// Copyright (c) 2010, Hadi Hariri
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of Hadi Hariri nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// =============================================================
//
//
// Parts of this Software use JsonFX Serialization Library which is distributed under the MIT License:
//
// Distributed under the terms of an MIT-style license:
//
// The MIT License
//
// Copyright (c) 2006-2009 Stephen M. McKamey
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
#endregion

using EasyHttp.Codecs;
using EasyHttp.Infrastructure;
using NUnit.Framework;

namespace EasyHttp.Specs.Specs
{
    [TestFixture(Category = "DynamicType")]
    public class DynamicSpecs
    {
        [Test]
        public void when_accessing_a_property_that_is_defined_it_should_return_the_value()
        {
            dynamic dynamicObject = new DynamicType();
            dynamicObject.Name = "Joe";

            var value = dynamicObject.Name;

            Assert.AreEqual("Joe", value);
        }

        [Test]
        public void when_accessing_a_property_that_is_not_defined_it_should_throw_property_not_found_exception()
        {
            dynamic dynamicObject = new DynamicType();

            var exception = Assert.Throws<PropertyNotFoundException>(() =>
            {
                var value = dynamicObject.Name;
            });

            Assert.AreEqual("Name", exception.PropertyName);
        }

        [Test]
        public void when_accessing_a_property_of_a_child_property_that_is_defined_it_should_return_the_value()
        {
            dynamic childObject = new DynamicType();

            childObject.Name = "Child";

            dynamic parentObject = new DynamicType();

            parentObject.Child = childObject;

            Assert.AreEqual("Child", parentObject.Child.Name);
        }

        [Test, Category("Infrastructure")]
        public void when_accessing_a_property_of_a_child_property_that_is_not_defined_it_should_set_property_name_to_name_of_property_not_found()
        {
            dynamic childObject = new DynamicType();

            dynamic parentObject = new DynamicType();

            parentObject.Child = childObject;

            var exception = Assert.Throws<PropertyNotFoundException>(() =>
            {
                var value = parentObject.Child.Name;
            });

            Assert.AreEqual("Name", exception.PropertyName);
        }
    }
}