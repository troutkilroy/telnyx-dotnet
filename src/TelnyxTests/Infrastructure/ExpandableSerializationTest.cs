// <copyright file="ExpandableSerializationTest.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Telnyx;
    using Telnyx.Infrastructure;
    using Xunit;

    public class ExpandableSerializationTest : BaseTelnyxTest
    {
        [Fact]
        public void SerializeNotExpanded()
        {
            var obj = new TestTopLevelObject
            {
                NestedId = "id_not_expanded",
                Nested = null,
            };

            var expected = "{\n  \"nested\": \"id_not_expanded\"\n}";
            Assert.Equal(expected, obj.ToJson().Replace("\r\n", "\n"));
        }

        [Fact]
        public void SerializeExpanded()
        {
            var nested = new TestNestedObject
            {
                Id = "id_expanded",
                Bar = 42,
            };
            var obj = new TestTopLevelObject
            {
                NestedId = nested.Id,
                Nested = nested,
            };

            var expected =
                "{\n  \"nested\": {\n    \"id\": \"id_expanded\",\n    \"bar\": 42\n  }\n}";
            Assert.Equal(expected, obj.ToJson().Replace("\r\n", "\n"));
        }

        [Fact]
        public void StringOrObjectMap()
        {
            var nested = new TestNestedObject
            {
                Id = "id_expanded",
                Bar = 42,
            };
            var obj = new TestTopLevelObject
            {
                NestedId = nested.Id,
                Nested = nested,
            };

            obj.InternalNested = "new_id";
            Assert.Equal("new_id", obj.NestedId);

            obj.InternalNested = new JObject
            {
                { "Id", "new2_id" },
                { "Bar", 44 },
            };

            Assert.Equal("new2_id", obj.NestedId);
        }

        [Fact]
        public void SerializeNull()
        {
            var obj = new TestTopLevelObject
            {
                NestedId = null,
                Nested = null,
            };

            var expected = "{\n  \"nested\": null\n}";
            Assert.Equal(expected, obj.ToJson().Replace("\r\n", "\n"));
        }

        private class TestNestedObject : TelnyxEntity, IHasId
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("bar")]
            public int Bar { get; set; }
        }

        private class TestTopLevelObject : TelnyxEntity
        {
            [JsonIgnore]
            public string NestedId { get; set; }

            [JsonIgnore]
            public TestNestedObject Nested { get; set; }

            [JsonProperty("nested")]
            internal object InternalNested
            {
                get {
                    return this.Nested ?? (object)this.NestedId;
                }

                set {
                    StringOrObject<TestNestedObject>.Map(value, s => this.NestedId = s, o => this.Nested = o);
                }
            }
        }
    }
}
