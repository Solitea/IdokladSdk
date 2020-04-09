using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.IntegrationTests.Core.Extensions;
using IdokladSdk.IntegrationTests.Core.Tags.Model;
using IdokladSdk.Models;
using IdokladSdk.Models.Common;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Modifiers.Expand.Common;
using IdokladSdk.Requests.Core.Modifiers.Expand.Structure;
using IdokladSdk.Requests.Core.Modifiers.Filters.Common;
using NUnit.Framework;

namespace IdokladSdk.IntegrationTests.Core.Tags
{
    public abstract class TaggableDocumentGetTestsBase<TClient, TDetail, TList, TGetModel, TGetListModel, TExpandModel, TFilterModel> : TestBase
        where TClient : BaseClient, IEntityDetail<TDetail>, IEntityList<TList>
        where TDetail : class, IGetDetailRequest<TGetModel>, IExpandable<TDetail, TExpandModel>
        where TList : class, IGetListRequest<TGetListModel>, IFilterable<TList, TFilterModel>
        where TGetModel : IEntityId, new()
        where TGetListModel : IEntityId, new()
    {
        protected const string TagsPropertyName = "Tags";
        protected const string TagIdsFilterPropertyName = "TagIds";

        protected const int Tag1Id = 990;
        protected const int Tag2Id = 991;
        protected const int Tag3Id = 992;

        protected TClient Client { get; private set; }

        protected abstract int EntityWithoutTagsId { get; }

        protected abstract int EntityWithTags1Id { get; }

        protected abstract int EntityWithTags2Id { get; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitDokladApi();
            Client = (TClient)Activator.CreateInstance(typeof(TClient), DokladApi.ApiContext);
        }

        [Test]
        public void GetDetail_Expand_ReturnsExpandedTags()
        {
            // Act
            var result = ExpandableDetail(this.EntityWithTags1Id)
                .Include(TagIncludeExpression())
                .Get<EntityTagDetails>()
                .AssertResult();

            // Assert
            this.AssertHasTags(result.Tags, new List<int> { Tag1Id, Tag2Id }, true);
        }

        [Test]
        public void GetDetail_WithoutTags_ReturnsEmptyTags()
        {
            // Act
            var result = Detail(this.EntityWithoutTagsId)
                .Get<EntityTagDetails>()
                .AssertResult();

            // Assert
            this.AssertHasEmptyTags(result.Tags);
        }

        [Test]
        public void GetDetail_WithTags_ReturnsTags()
        {
            // Act
            var result = Detail(this.EntityWithTags1Id)
                .Get<EntityTagDetails>()
                .AssertResult();

            // Assert
            this.AssertHasTags(result.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public void GetList_MultipleTagsFilter_ReturnsEntitiesWithTags()
        {
            // Act
            var result = FilterableList()
                .Filter(f => TagIdsFilterItem(f).Contains(new int[] { Tag1Id, Tag2Id }))
                .Get<EntityTags>()
                .AssertResult();

            // Assert
            var items = result.Items.ToList();
            Assert.That(items.Count, Is.EqualTo(1));
            var entity = items.FirstOrDefault(i => i.Id == this.EntityWithTags1Id);
            this.AssertHasTags(entity.Tags, new List<int> { Tag1Id, Tag2Id });
        }

        [Test]
        public void GetList_NonExistingTagsCombinationFilter_ReturnsEmptyList()
        {
            // Act
            var result = FilterableList()
                .Filter(f => TagIdsFilterItem(f).Contains(new int[] { Tag1Id, Tag3Id }))
                .Get<EntityTags>()
                .AssertResult();

            // Assert
            Assert.That(result.Items.Count(), Is.Zero);
        }

        [Test]
        public void GetList_ReturnsAllEntities()
        {
            // Act
            var result = PageableList()
                .PageSize(50)
                .Get<EntityTags>()
                .AssertResult();

            // Assert
            var items = result.Items.ToList();
            Assert.That(items.Count, Is.GreaterThanOrEqualTo(3));
            var entity = items.FirstOrDefault(i => i.Id == this.EntityWithoutTagsId);
            this.AssertHasEmptyTags(entity.Tags);
            entity = items.FirstOrDefault(i => i.Id == this.EntityWithTags1Id);
            this.AssertHasTags(entity.Tags, new List<int> { Tag1Id, Tag2Id });
            entity = items.FirstOrDefault(i => i.Id == this.EntityWithTags2Id);
            this.AssertHasTags(entity.Tags, new List<int> { Tag2Id, Tag3Id });
        }

        [Test]
        public void GetList_SingleTagFilter_ReturnsEntitiesWithTag()
        {
            // Act
            var result = FilterableList()
                .Filter(f => TagIdsFilterItem(f).Contains(Tag2Id))
                .Get<EntityTags>()
                .AssertResult();

            // Assert
            var items = result.Items;
            Assert.That(items.Count(), Is.EqualTo(2));
            var entity = items.FirstOrDefault(i => i.Id == this.EntityWithTags1Id);
            this.AssertHasTags(entity.Tags, new List<int> { Tag1Id, Tag2Id });
            entity = items.FirstOrDefault(i => i.Id == this.EntityWithTags2Id);
            this.AssertHasTags(entity.Tags, new List<int> { Tag2Id, Tag3Id });
        }

        protected void AssertHasEmptyTagIds(IEnumerable<int> tagIds)
        {
            Assert.That(tagIds, Is.Not.Null.And.Empty);
        }

        protected void AssertHasEmptyTags(IEnumerable<TagDocumentListGetModel> tags)
        {
            Assert.That(tags, Is.Not.Null.And.Empty);
        }

        protected void AssertHasTagIds(IEnumerable<int> returnedIds, List<int> expectedIds)
        {
            Assert.That(returnedIds, Is.Not.Null.And.Count.EqualTo(expectedIds.Count));
            for (int i = 0; i < returnedIds.Count(); i++)
            {
                var returnedId = returnedIds.ElementAt(i);
                var expectedId = expectedIds.ElementAt(i);
                Assert.That(returnedId, Is.EqualTo(expectedId));
            }
        }

        protected void AssertHasTags(IEnumerable<TagDocumentGetModel> returnedTags, List<int> expectedIds, bool isExpand = false)
        {
            AssertHasTags(returnedTags.Cast<TagDocumentListGetModel>(), expectedIds, isExpand);
        }

        protected void AssertHasTags(IEnumerable<TagDocumentListGetModel> returnedTags, List<int> expectedIds, bool isExpand = false)
        {
            Assert.That(returnedTags, Is.Not.Null.And.Count.EqualTo(expectedIds.Count));
            for (int i = 0; i < returnedTags.Count(); i++)
            {
                var returnedTag = returnedTags.ElementAt(i);
                var expectedId = expectedIds.ElementAt(i);
                Assert.That(returnedTag.TagId, Is.EqualTo(expectedId));
                var expandedTag = returnedTag as TagDocumentGetModel;

                if (isExpand)
                {
                    Assert.That(expandedTag.Tag, Is.Not.Null);
                    Assert.That(expandedTag.Tag.Id, Is.EqualTo(expectedId));
                    Assert.That(expandedTag.Tag.Name, Is.Not.Null.And.Not.Empty);
                    Assert.That(expandedTag.Tag.Color, Is.Not.Null.And.Not.Empty);
                }
                else if (expandedTag != null)
                {
                    Assert.That(expandedTag.Tag, Is.Null);
                }
            }
        }

        protected IGetDetailRequest<TGetModel> Detail(int id) => (IGetDetailRequest<TGetModel>)((IEntityDetail<TDetail>)Client).Detail(id);

        protected IExpandable<TDetail, TExpandModel> ExpandableDetail(int id) => (IExpandable<TDetail, TExpandModel>)((IEntityDetail<TDetail>)Client).Detail(id);

        protected IFilterable<TList, TFilterModel> FilterableList() => (IFilterable<TList, TFilterModel>)((IEntityList<TList>)Client).List();

        protected IPageable<TList> PageableList() => (IPageable<TList>)((IEntityList<TList>)Client).List();

        protected IGetListRequest<TGetListModel> List() => (IGetListRequest<TGetListModel>)((IEntityList<TList>)Client).List();

        protected ContainIdFilterItem TagIdsFilterItem(TFilterModel filterModel)
        {
            var tagIdsProperty = typeof(TFilterModel).GetProperty(TagIdsFilterPropertyName);
            return (ContainIdFilterItem)tagIdsProperty.GetValue(filterModel);
        }

        protected Expression<Func<TExpandModel, ExpandableEntity>> TagIncludeExpression()
        {
            var parameter = Expression.Parameter(typeof(TExpandModel), "x");
            Expression body = Expression.PropertyOrField(parameter, TagsPropertyName);
            body = Expression.PropertyOrField(body, nameof(TagsExpand.Tag));
            return Expression.Lambda<Func<TExpandModel, ExpandableEntity>>(body, parameter);
        }
    }
}
