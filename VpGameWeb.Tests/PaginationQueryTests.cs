using VpGameWeb.Models.Dtos;

namespace VpGameWeb.Tests;

public class PaginationQueryTests
{
    [Test]
    public void Defaults_ToFirstPageAndTwentyItems()
    {
        var query = new PaginationQuery();

        Assert.Multiple(() =>
        {
            Assert.That(query.Page, Is.EqualTo(1));
            Assert.That(query.PageSize, Is.EqualTo(20));
            Assert.That(query.Skip, Is.EqualTo(0));
        });
    }

    [Test]
    public void PageAndPageSize_AreClampedToSafeValues()
    {
        var query = new PaginationQuery
        {
            Page = -10,
            PageSize = 200
        };

        Assert.Multiple(() =>
        {
            Assert.That(query.Page, Is.EqualTo(1));
            Assert.That(query.PageSize, Is.EqualTo(100));
        });
    }

    [Test]
    public void Skip_UsesNormalizedPageAndPageSize()
    {
        var query = new PaginationQuery
        {
            Page = 3,
            PageSize = 10
        };

        Assert.That(query.Skip, Is.EqualTo(20));
    }
}
