using System;
using System.Collections.Generic;

namespace PCStoreGraphQL.API.Types;

public partial class CommentType
{
    public int? CommentId { get; set; }

    public int Article { get; set; }

    public int Stars { get; set; }

    public DateTime? CommentDate { get; set; }

    public int UserId { get; set; }

    public string? Comment1 { get; set; }
}
