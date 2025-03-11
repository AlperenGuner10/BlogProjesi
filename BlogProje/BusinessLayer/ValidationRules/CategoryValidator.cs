using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(c=>c.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
			RuleFor(c=>c.CategoryDesc).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz.");
			RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Katefori adı en az 2 karakterli olmalıdır.");
			RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Katefori adı en fazla 50 karakterli olmalıdır.");
		}
	}
}
