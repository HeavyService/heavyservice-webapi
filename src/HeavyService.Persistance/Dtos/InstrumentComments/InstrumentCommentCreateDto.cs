﻿namespace HeavyService.Persistance.Dtos.InstrumentComments;

public class InstrumentCommentCreateDto
{
    public long ReplyId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsEdited { get; set; }
}