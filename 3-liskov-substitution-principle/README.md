# Liskov substitution principle

The application reads a textual file from a specified location and converts the text into HTML by wrapping each paragraph in `p` tags. The output is then written into a new HTML file.

The application is also capable of replacing some MD tags with their HTML equivalent ones. However, the application may need to support other input formats in the future. The only thing that is certain at the moment is that every paragraph needs to be wrapped in `p` HTML tag for any scenario.

Single responsibility principle is adhered to by having file processing and text processing logic performed by separate classes. `FileProcessor` is responsible for reading files and creating new files. `TextProcessor` and its derived class, `MdTextProcessor`, are responsible for processing text.

Open-closed principle is adhered to by having the base text-processing functionality in `TextProcessor` and only applying any additional specialist functionality by a derived class - `MdTextProcessor`. If we need to be able to process a different input format, we can just create a new derived class specific to that format. The base functionality in TextProcessor will not be modified.

Liskov substitution principle is adhered to by not changing the output behavior of `ConvertText()` method from `TextProcessor` base class. This way, even if you replace any instance of `TextProcessor` with an instance of `MdTextProcessor`, the results that you would receive from this method will be identical for the same input value is provided.

For more detailed description, follow the link below:

[Liskov substitution principle in C#](https://scientificprogrammer.net/2019/11/04/liskov-substitution-principle-in-c/) 