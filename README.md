# Automated-Testing-Tool
This tool helps an instructor to create and grade a test. A test can have essay questions, multiple choice questions and fill in the blanks. For a student, test is downloaded from XML using XSD which he/she can attempt. All the responses provided by the student are automatically graded and stored in XML.

An instructor can add any number of questions in the test. For essay question, question statement, keywords, word limit and number of paragraphs are needed. All the questions are stored in the form of an XML using XSD and a class generated from it, which can also be downloaded for later use.

While grading an essay, firstly the code looks for all the keywords and then it generates all the synonyms of keywords and look for them. Followed by this, a grammar check is performed on the essay. Marks are also provided based on the number of words and paragraphs in an essay.

Finally, a complete grade sheet is generated for a student in the form of an XML which can also be seen using XSD and downloaded by the instructor.


