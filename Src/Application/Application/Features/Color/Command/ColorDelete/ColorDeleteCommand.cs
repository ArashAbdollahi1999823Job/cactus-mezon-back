using MediatR;

namespace Application.Features.Color.Command.ColorDelete;

public class ColorDeleteCommand:IRequest<bool>
{
    public long Id { get; set; }

    public ColorDeleteCommand(long id)
    {
        Id = id;
    }
}