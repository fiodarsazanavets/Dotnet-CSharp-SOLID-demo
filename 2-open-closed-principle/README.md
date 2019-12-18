# Open-closed principle

The application reads a textual file from a specified location and converts the text into HTML by wrapping each paragraph in P tags. The output is then written into a new HTML file.

The application is also capable of replacing some MD tags with their HTML equivalent ones. However, the application may need to support other input formats in the future. The only thing that is certain at the moment is that every paragraph needs to be wrapped in P HTML tag for any scenario.

Single responsibility principle is adhered to by having file processing and text processing logic performed by separate classes. FileProcessor is responsible for reading files and creating new files. TextProcessor and it's derived class, MdTextProcessor, are responsible for processing text.

Open-closed principle is adhered to by having the base text-processing functionality in TextProcessor and only applying any additional specialist functionality by a derived class - MdTextProcessor. If we need to be able to process a different input format, we can just create a new derived class specific to that format. The base functionality in TextProcessor will not be modified.

For more detailed description, follow the link below:

[Why open-closed principle is important](https://scientificprogrammer.net/2019/10/22/why-open-closed-principle-is-important/) 