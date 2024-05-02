﻿using BookStore.Application.Dtos.Common;

namespace BookStore.Application.Dtos.Author;
public sealed class AuthorForListDto : BaseDto
{
  public string? Name { get; set; }
}