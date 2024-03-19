using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Moq;
using Xunit;

namespace UnitTests.DataAccess;

public class UnitOfWorkTest
{
    private readonly Mock<ToolsContext> _toolsContext;
    private readonly UnitOfWork _unitOfWork;
        
    public UnitOfWorkTest()
    {
        this._toolsContext = new Mock<ToolsContext>();
        this._unitOfWork = new UnitOfWork(this._toolsContext.Object);
    }
        
    [Fact]
    public async Task TestingSucess_ValidateSave()
    {
        await this._unitOfWork.Save();
        this._toolsContext.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()));
    }
        
    [Fact]
    public void TestingSucess_ValidateDispose()
    {
        this._unitOfWork.Dispose();
        this._toolsContext.Verify(context => context.Dispose(), Times.Exactly(1));
        this._unitOfWork.Dispose();
        this._toolsContext.Verify(context => context.Dispose(), Times.Exactly(1));
    }
}
