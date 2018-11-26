using Insist.Exceptions;
using System.Collections.Generic;
using Xunit;

namespace Insist.Tests.Unit
{
    public class CollectionTests
    {
        [Fact(DisplayName = "Can check a collection for a null value")]
        public void CanCheckCollectionForNullValue()
        {
            var collection = new List<string> { "foo", "bar", null };

            Assert.Throws<CollectionContainsNullValueException>(() => Insist.HasNoNulls(collection));
            Assert.Throws<TestException>(() => Insist.HasNoNulls(collection, customException: new TestException()));
            Insist.HasNoNulls(collection, suppressExceptions: true);

            collection.Remove(null);

            Insist.HasNoNulls(collection);
        }

        [Fact(DisplayName = "Can check a collection of T for a null value")]
        public void CanCheckTypedCollectionForNullValue()
        {
            var dogs = new List<Dog>
            {
                new Dog{ Id = 1, Name = "Matilda", Type = "German Shepherd", Age = 9 },
                new Dog{ Id = 2, Name = "Lancelot", Type = "German Shepherd", Age = 9},
                new Dog{ Id = 3, Name = "Zeus", Type = "Leonberger", Age = 4}
            };

            Insist.HasNoNulls(dogs, nameof(Dog.Age));

            dogs[2].Age = null;

            Assert.Throws<CollectionContainsNullValueException>(() => Insist.HasNoNulls(dogs, nameof(Dog.Age)));
            Assert.Throws<TestException>(() => Insist.HasNoNulls(dogs, nameof(Dog.Age), customException: new TestException()));
            Insist.HasNoNulls(dogs, nameof(Dog.Age), suppressExceptions: true);
        }
    }

    class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Age { get; set; }
    }
}
