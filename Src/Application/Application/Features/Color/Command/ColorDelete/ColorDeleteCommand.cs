using MediatR;

namespace Application.Features.Color.Command.ColorDelete;

public class ColorDeleteCommand:IRequest<bool>
{
    public Guid Id { get; set; }

    public ColorDeleteCommand(Guid id)
    {
        Id = id;
    }
}