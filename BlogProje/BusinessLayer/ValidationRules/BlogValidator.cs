﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogValidator : AbstractValidator<Blog>
	{
		public BlogValidator()
		{
			RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz");
			RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz");
			RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
			RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakteri geçmeyiniz");
			RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("Lütfen en az 4 karakter yazınız");
		}
	}
}
