# Models

## Book Model

Represents a book in the library.

### Properties

- BookId (Primary Key)
- Title
- Author
- ISBN
- PublishedDate
- IsAvailable

### Important Attributes

#### [Required]

Ensures a value must be provided.

#### [StringLength]

Limits the maximum length.

#### [RegularExpression]

Validates ISBN format.

#### [BindNever]

Prevents ASP.NET MVC from binding sensitive properties from HTTP requests.
