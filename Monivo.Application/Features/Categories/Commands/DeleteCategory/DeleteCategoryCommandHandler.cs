using MediatR;
using Monivo.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAndUserIdAsync(request.Id, request.UserId);


            if (category == null)
                throw new UnauthorizedAccessException(
                    "You are not authorized to delete this category.");

            _categoryRepository.Delete(category);

            await _categoryRepository.SaveChangesAsync();
        }
    }
}
