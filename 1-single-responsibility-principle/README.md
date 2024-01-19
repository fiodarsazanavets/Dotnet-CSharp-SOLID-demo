# Single responsibility principle

The application reads a textual file from a specified location and converts the text into HTML by wrapping each paragraph in `p` tags. The output is then written into a new HTML file.

Single responsibility principle is adhered to by having file processing and text processing logic performed by separate classes. `FileProcessor` is responsible for reading files and creating new files. `TextProcessor` is responsible for processing text.

For more detailed description, follow the link below:

[Why you must use single responsibility principle](https://scientificprogrammer.net/2019/09/30/why-you-must-use-single-responsibility-principle/) 