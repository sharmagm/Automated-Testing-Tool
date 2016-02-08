
using Microsoft.Office.Interop.Word;
using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XMLGradingAssignment
{
    /// <summary>
    /// This class helps an instructor to dynamically create and grade a test and allow students to attempt a test.
    /// </summary>
    public partial class GradingTool : Form
    {
        int quesCount = 1;
        List<TestQuestion> testQuesList = new List<TestQuestion>();
        List<TestAnswersAnswer> ansList = new List<TestAnswersAnswer>();
        string selectedQuesType = string.Empty;
        int questionIndex = 0;
        int totalQuestions = 0;
        double marks = 0;
        Test test;
        Test finalTest;

        TestAnswers testAnswer = new TestAnswers();
        TestAnswers finalTestAnswer;

        RadioButton option1;
        RadioButton option2;
        RadioButton option3;
        RadioButton option4;
        TextBox textAnswer;

        enum QuesTypeVal
        {
            MCQ, Text, EssayText
        }

        /// <summary>
        /// Initializes and control all the controls
        /// </summary>
        public GradingTool()
        {
            InitializeComponent();
            HideMCQtypeControls();
            HideEssayTypeControls();
            HideTextTypeControls();
            addAnotherQuesBtn.Visible = false;
            generateTestXMLBtn.Visible = false;
            endTestBtn.Visible = false;
            nextQuesBtn.Visible = false;
            nextQuesLbl.Visible = false;
            essayAnswerRexponseTxt.Visible = false;
            submitTestBtn.Visible = false;
            uploadXMLBtn.Visible = false;
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            nextQuesBtn.Visible = false;
            nextQuesLbl.Visible = false;
            AddQuestionBtn.Visible = true;
            button2.Visible = false;
            textBox_info.Visible = false;
            //createxsd();
        }

        /// <summary>
        /// It enables user to select the type of question he wants to add to test.
        /// It calls the desired methods to provide fields to add for the type of question selected by user.
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                label2.Text = string.Empty;
                label2.Text = "Question " + quesCount.ToString();
                label2.Visible = true;

                AddQuestionBtn.Visible = false;
                addAnotherQuesBtn.Visible = true;
                endTestBtn.Visible = true;
                comboBox1.Visible = false;
                label_questype.Visible = false;

                if (comboBox1.SelectedItem.ToString() == "Text Question")
                {
                    selectedQuesType = QuesTypeVal.Text.ToString();
                    HideMCQtypeControls();
                    HideEssayTypeControls();
                    ShowTextTypeControls();

                }
                else if (comboBox1.SelectedItem.ToString() == "Multiple Choice Question")
                {
                    selectedQuesType = QuesTypeVal.MCQ.ToString();
                    HideTextTypeControls();
                    HideEssayTypeControls();
                    ShowMCQTypeControls();

                }
                else if (comboBox1.SelectedItem.ToString() == "Essay Question")
                {
                    selectedQuesType = QuesTypeVal.EssayText.ToString();
                    HideMCQtypeControls();
                    HideTextTypeControls();
                    ShowEssayTypeControls();

                }
                quesCount++;
            }
        }    

        /// <summary>
        /// User can select to add another question by clicking on the "Add Question" button.
        /// This method helps to load the option to select a question type, stores the question to XML 
        /// and hide the controls to support the functionality.
        /// </summary>
        private void addAnotherQuesBtn_Click(object sender, EventArgs e)
        {
            if (!ShowErrors())
            {
                comboBox1.Visible = true;
                label_questype.Visible = true;
                quesCount = 1;
                StoreQuestionResponses();
                HideMCQtypeControls();
                HideEssayTypeControls();
                HideTextTypeControls();
                ClearAllControls();
                comboBox1.SelectedIndex = -1;
            } 
        }        

        /// <summary>
        /// This method stores the question and its responses provided by the user in the object of TestQuestion class.
        /// </summary>
        private void StoreQuestionResponses()
        {
            TestQuestion ques = new TestQuestion();
            ques.QuestionText = quesTxt.Text;
            ques.Number = quesCount;
            if (selectedQuesType == QuesTypeVal.MCQ.ToString())
            {
                ques.Type = "MCQ";

                var option1 = new TestQuestionOption1 { Answer = "No", Value = textBox2.Text };
                var option2 = new TestQuestionOption2 { Answer = "No", Value = textBox3.Text };
                var option3 = new TestQuestionOption3 { Answer = "No", Value = textBox4.Text };
                var option4 = new TestQuestionOption4 { Answer = "No", Value = textBox5.Text };

                if (radioButton1.Checked == true)
                {
                    option1.Answer = "Yes";
                }
                else if (radioButton2.Checked == true)
                {
                    option2.Answer = "Yes";
                }
                else if (radioButton3.Checked == true)
                {
                    option3.Answer = "Yes";
                }
                else if (radioButton4.Checked == true)
                {
                    option4.Answer = "Yes";
                }

                ques.Option1 = option1;
                ques.Option2 = option2;
                ques.Option3 = option3;
                ques.Option4 = option4;
            }
            else if (selectedQuesType == QuesTypeVal.Text.ToString())
            {
                ques.Type = "Text";

                TestQuestionAnswer ans = new TestQuestionAnswer();
                ans.Text = textTypeAnswerTxt.Text;

                ques.Answer = ans;
            }
            else if (selectedQuesType == QuesTypeVal.EssayText.ToString())
            {
                ques.Type = "EssayText";

                ques.NumberOfParagraphs = Convert.ToInt32(textTypeAnswerTxt.Text);
                ques.TotalNumberOfWords = Convert.ToInt32(noOfKeywordsTxt.Text);

                TestQuestionAnswer essayAns = new TestQuestionAnswer();
                List<string> keywordList = new List<string>();
                keywordList = essayAnsTxt.Text.Split(';').ToList<string>();
                essayAns.Keyword = new string[keywordList.Count];

                int i = 0;
                foreach (string k in keywordList)
                {
                    essayAns.Keyword[i] = k;
                    i++;
                }

                ques.Answer = essayAns;
            }

            testQuesList.Add(ques);
        }        

        /// <summary>
        /// From the TestQuestion XSD class, this method dynamically generates an XML 
        /// and stores all the created questions and their responses to it.
        /// </summary>
        private void generateTestXMLBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            Test testResponse = new Test();
            testResponse.Question = new TestQuestion[testQuesList.Count];
            foreach (var question in testQuesList)
            {
                testResponse.Question[i] = question;
                i++;
            }
            try
            {
                var serializer = new XmlSerializer(typeof(Test));
                using (var stream = new StreamWriter("D:\\test.xml"))
                    serializer.Serialize(stream, testResponse);

                MessageBox.Show("Test XML downloaded successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in downloading Test XML. Please create the test again");
                button1_Click(sender, e);
            }
        }

        /// <summary>
        /// This method stores the result of all the questions.
        /// </summary>
        private void endTestBtn_Click(object sender, EventArgs e)
        {
            if (!ShowErrors())
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    StoreQuestionResponses();
                }

             button2.Visible = true;
             ClearAllControls();
             generateTestXMLBtn.Visible = true;
             HideEssayTypeControls();
             HideMCQtypeControls();
             HideTextTypeControls();
             endTestBtn.Visible = false;
             addAnotherQuesBtn.Visible = false;
             comboBox1.SelectedIndex = -1;
             comboBox1.Visible = false;
             label_questype.Visible = false;

             MessageBox.Show("Test XML created successfully. Please click on Generate Test XML to download it");
            }             
        }
        
        /// <summary>
        /// This method is called when a student wans to attempt a test.
        /// It reads an XML in which all the questions and responses are stored and create a test for the student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox_info.Visible = false;
            button2.Visible = false;
            nextQuesBtn.Visible = true;
            nextQuesLbl.Visible = true;
            addAnotherQuesBtn.Visible = false;
            endTestBtn.Visible = false;

            XmlSerializer ser = new XmlSerializer(typeof(Test));
            try
            {
                FileStream fs = new FileStream("D:\\test.xml", FileMode.Open);
                test = ser.Deserialize(fs) as Test;
                totalQuestions = test.Question.Count();

                CreateTestQuestions();
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show("No test file exists in your system. Go ahead and create one!");
                button1_Click(sender, e);
            }     
        }

        /// <summary>
        /// This method generates each question saved in XML file for students to answer.
        /// </summary>
        private void CreateTestQuestions()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            essayAnswerRexponseTxt.Visible = false;

            if (test != null)
            {
                if (test.Question[questionIndex].Type == QuesTypeVal.MCQ.ToString())
                {
                    Label questionNo = new Label();
                    questionNo.Text = "vhvhvkhbhbjbjnknklnknklnklnklnklnklnklnlknlknlknlknklnknklnlkn";
                    tableLayoutPanel1.Controls.Add(questionNo, 0, 0);

                    option1 = new RadioButton();
                    option1.Text = test.Question[questionIndex].Option1.Value;
                    tableLayoutPanel1.Controls.Add(option1, 0, 1);

                    option2 = new RadioButton();
                    option2.Text = test.Question[questionIndex].Option2.Value;
                    tableLayoutPanel1.Controls.Add(option2, 0, 2);

                    option3 = new RadioButton();
                    option3.Text = test.Question[questionIndex].Option3.Value;
                    tableLayoutPanel1.Controls.Add(option3, 0, 3);

                    option4 = new RadioButton();
                    option4.Text = test.Question[questionIndex].Option4.Value;
                    tableLayoutPanel1.Controls.Add(option4, 0, 4);
                }
                else if (test.Question[questionIndex].Type == QuesTypeVal.Text.ToString())
                {
                    Label questionNo = new Label();
                    questionNo.Text = "Question " + test.Question[questionIndex].Number.ToString() + " : " + test.Question[questionIndex].QuestionText;
                    tableLayoutPanel1.Controls.Add(questionNo, 0, 0);

                    Label answerVal = new Label();
                    answerVal.Text = "Answer " + test.Question[questionIndex].Number.ToString() + " : ";
                    tableLayoutPanel1.Controls.Add(answerVal, 0, 1);

                    textAnswer = new TextBox();
                    textAnswer.Text = string.Empty;
                    textAnswer.Width = 150;
                    tableLayoutPanel1.Controls.Add(textAnswer, 0, 2);
                }
                else if (test.Question[questionIndex].Type == QuesTypeVal.EssayText.ToString())
                {
                    Label questionNo = new Label();
                    questionNo.Text = "Question " + test.Question[questionIndex].Number.ToString() + " : " + test.Question[questionIndex].QuestionText;
                    tableLayoutPanel1.Controls.Add(questionNo, 0, 0);

                    Label answerVal = new Label();
                    answerVal.Text = "Answer " + test.Question[questionIndex].Number.ToString() + " : ";
                    tableLayoutPanel1.Controls.Add(answerVal, 0, 1);

                    essayAnswerRexponseTxt.Visible = true;
                }
                questionIndex++;
            }            
        }

        /// <summary>
        /// This method calls the next question in the test and also saves the student's answer to another XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextQuesBtn_Click(object sender, EventArgs e)
        {
            GenerateAnswerXML();
            CreateTestQuestions();
            if (questionIndex == totalQuestions)
            {
                nextQuesBtn.Visible = false;
                submitTestBtn.Visible = true;
            }
        }

        /// <summary>
        /// This method helps in storing all the answers given by a student to an XML which can be referrenced by a user.
        /// </summary>
        private void GenerateAnswerXML()
        {
            TestAnswersAnswer ansVal = new TestAnswersAnswer();
            if (test.Question[questionIndex - 1].Type == QuesTypeVal.MCQ.ToString())
            {
                if (option1.Checked == true)
                {
                    ansVal.Value = option1.Text;
                }
                else if (option2.Checked == true)
                {
                    ansVal.Value = option2.Text;
                }
                else if (option3.Checked == true)
                {
                    ansVal.Value = option3.Text;
                }
                else if (option4.Checked == true)
                {
                    ansVal.Value = option4.Text;
                }
            }
            else if (test.Question[questionIndex - 1].Type == QuesTypeVal.Text.ToString())
            {
                ansVal.Value = textAnswer.Text;
            }
            else if (test.Question[questionIndex - 1].Type == QuesTypeVal.EssayText.ToString())
            {
                ansVal.Value = essayAnswerRexponseTxt.Text;
            }
            ansVal.Type = test.Question[questionIndex - 1].Type;
            ansVal.Number = test.Question[questionIndex - 1].Number;
            ansList.Add(ansVal);
        }

        /// <summary>
        /// This method generates an XML to store answers submitted by a student.
        /// </summary>
        private void GenerateStudentsResponseXML(object sender, EventArgs e)
        {             
            int i = 0;

            GenerateAnswerXML();
            
            testAnswer.Answer = new TestAnswersAnswer[ansList.Count];
            foreach (var ans in ansList)
            {
                testAnswer.Answer[i++] = ans;
            }

            var serializer = new XmlSerializer(typeof(TestAnswers));
            using (var stream = new StreamWriter("D:\\StudentResponse.xml"))
                serializer.Serialize(stream, testAnswer);

            CalculateMarks();
        }

        /// <summary>
        /// It evaluates the responses provided by the student with the responses given by a instructor to grade a test using two separate XMLs.
        /// MCQs and Fill in the blanks type of questions are graded by comparing the responses, while Essay question is graded based on the 
        /// number of keywords or their synonyms used, grammatical errors, spellcheck, word limit and paragraphs.
        /// </summary>
        private void CalculateMarks()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Test));

            finalTest = ser.Deserialize(new FileStream("D:\\test.xml", FileMode.Open)) as Test;
            totalQuestions = test.Question.Count();

            ser = new XmlSerializer(typeof(TestAnswers));

            finalTestAnswer = ser.Deserialize(new FileStream("D:\\StudentResponse.xml", FileMode.Open)) as TestAnswers;
            List<TestQuestion> quesList = new List<TestQuestion>();
            for (int i = 0; i < totalQuestions; i++)
            {
                quesList.Add(finalTest.Question[i]);
            }

            int j = 0;
            double essayMarks = 100.0f;
            foreach (var question in quesList)
            {
                if (question.Type == QuesTypeVal.MCQ.ToString())
                {
                    if (question.Option1.Answer == "Yes" && question.Option1.Value == finalTestAnswer.Answer[j].Value)
                    {
                        marks += 5;
                    }
                    else if (question.Option2.Answer == "Yes" && question.Option2.Value == finalTestAnswer.Answer[j].Value)
                    {
                        marks += 5;
                    }
                    else if (question.Option3.Answer == "Yes" && question.Option3.Value == finalTestAnswer.Answer[j].Value)
                    {
                        marks += 5;
                    }
                    else if (question.Option4.Answer == "Yes" && question.Option4.Value == finalTestAnswer.Answer[j].Value)
                    {
                        marks += 5;
                    }
                    j++;
                }
                else if (question.Type == QuesTypeVal.Text.ToString())
                {
                    if (question.Answer.Text == finalTestAnswer.Answer[j].Value)
                    {
                        marks += 5;
                    }
                    j++;
                }
                else if (question.Type == QuesTypeVal.EssayText.ToString())
                {
                    string essayResponse = finalTestAnswer.Answer[j].Value;
                    int nKeyword = question.Answer.Keyword.Count();                    
                    double keywordMark = 40.0 / (double)nKeyword;
                    int checkSynonym = 0;
                    double wordMarks = 0.0f;
                    List<string> essayList = new List<string>();
                    var essayString = Regex.Split(essayResponse, @"[\n]+");
                    int noParagraphs = essayString.Count();
                    bool nParaCorrect = false;
                    for (int i = 0; i < noParagraphs; i++)
                    {
                        if (essayString[i] != string.Empty)
                            essayList.Add(essayString[i]);
                    }
                    if (essayList.Count() != question.NumberOfParagraphs)
                    {
                        essayMarks = 20;
                    }
                    else
                    {
                        List<string> wordList = new List<string>();
                        foreach (string essayPara in essayList)
                        {
                            var s = Regex.Split(essayPara, @"[,\s\n]+");
                            foreach (string k in s)
                            {
                                wordList.Add(k);
                            }
                        }
                        if (wordList.Count >= question.TotalNumberOfWords)
                        {
                            essayMarks = 20;
                        }
                        else
                        {
                            bool grammarCheck = true;
                            Microsoft.Office.Interop.Word.Application myWord = new Microsoft.Office.Interop.Word.Application();
                            foreach (string essay in essayList)
                            {
                                grammarCheck = myWord.CheckGrammar(essay);
                                if (!grammarCheck)
                                {
                                    essayMarks -= 5;
                                }
                            }

                            wordMarks = 40.0 / (double)wordList.Count();
                            foreach (string word in wordList)
                            {
                                using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                                {
                                    if (!hunspell.Spell(word))
                                    {
                                        essayMarks -= wordMarks;
                                    }
                                }
                            }

                            bool keyPresent = false;
                            for (int i = 0; i < nKeyword; i++)
                            {
                                if (!essayResponse.Contains(question.Answer.Keyword[i]))
                                {
                                    List<string> stringArr = new List<string>();
                                    stringArr.Add(question.Answer.Keyword[i]);
                                    SynonymInfo theSynonyms = myWord.SynonymInfo[question.Answer.Keyword[i]];
                                    foreach (var Meaning in theSynonyms.MeaningList as Array)
                                    {
                                        if (stringArr.Contains(Meaning) == false) stringArr.Add((string)Meaning);
                                    }
                                    for (int ii = 0; ii < stringArr.Count; ii++)
                                    {
                                        theSynonyms = myWord.SynonymInfo[stringArr[ii]];
                                        foreach (string Meaning in theSynonyms.MeaningList as Array)
                                        {
                                            if (stringArr.Contains(Meaning)) continue;
                                            stringArr.Add(Meaning);
                                        }
                                        if (stringArr.Count >= 10)
                                        {
                                            stringArr.ToArray();
                                            break;
                                        }
                                    }
                                    foreach (string key in stringArr)
                                    {
                                        if (essayResponse.Contains(key))
                                        {
                                            keyPresent = true;
                                        }
                                    }
                                    if (!keyPresent)
                                    {
                                        essayMarks -= keywordMark;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            marks += essayMarks;
        }

        /// <summary>
        /// It displays the error message wherever necessary.
        /// </summary>
        /// <returns></returns>
        private bool ShowErrors()
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if (quesTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter a question");
                    return true;
                }
                else if (textBox2.Text.Trim() == String.Empty || textBox3.Text.Trim() == String.Empty || textBox4.Text.Trim() == String.Empty ||
                  textBox5.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter all 4 multiple choice options");
                    return true;
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    MessageBox.Show("Please select one option as answer");
                    return true; ;
                }
                else
                {
                    return false;
                }
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                if (quesTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter a question");
                    return true;
                }
                else if (textTypeAnswerTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter an answer");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (quesTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter a question");
                    return true;
                }
                else if (textTypeAnswerTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter No of Paragraphs");
                    return true;
                }
                else if (noOfKeywordsTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter Number of Words");
                    return true;
                }
                else if (essayAnsTxt.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please enter Keywords");
                    return true;
                }
                else
                {
                    int num;
                    string Str = textTypeAnswerTxt.Text.Trim();
                    bool IsNum = int.TryParse(Str, out num);
                    if (!IsNum)
                    {
                        MessageBox.Show("Please enter a valid number in No of Paragraphs");
                        return true;
                    }
                    else
                    {
                        Str = noOfKeywordsTxt.Text.Trim();
                        bool IsNum2 = int.TryParse(Str, out num);
                        if (!IsNum2)
                        {
                            MessageBox.Show("Please enter a valid number in No of Words");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Helps in generating an XSD for a test format XML.
        /// </summary>
        private void createxsd()
        {
            XmlReader reader = XmlReader.Create("D:/response.xml");
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchemaInference schema = new XmlSchemaInference();
            schemaSet = schema.InferSchema(reader);
            var settings = new XmlWriterSettings();
            settings.Indent = true;

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stringWriter, settings))
                    {
                        s.Write(writer);
                    }

                    essayAnswerRexponseTxt.Visible = true;
                    essayAnswerRexponseTxt.Text = stringWriter.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_info.Text = "This tool is designed to create and grade test automatically.\r\nYou can create a new test by clicking on Create test.\r\nClick on Attempt test to attempt an test.\r\nIf you attempt a test, it will pick the last test which was created by you.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label_questype.Visible = true;
        }

        private void ClearAllControls()
        {
            quesTxt.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textTypeAnswerTxt.Text = string.Empty;
            noOfKeywordsTxt.Text = string.Empty;
            essayAnsTxt.Text = string.Empty;
        }

        private void HideMCQtypeControls()
        {
            label2.Visible = false;
            quesTxt.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void ShowMCQTypeControls()
        {
            label2.Visible = true;
            quesTxt.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }

        private void ShowEssayTypeControls()
        {
            quesTxt.Visible = true;
            label2.Visible = true;
            txtTypeAnswerLbl.Text = "Total No. of Paragraphs :";
            txtTypeAnswerLbl.Visible = true;
            textTypeAnswerTxt.Visible = true;
            noOfWordsLbl.Visible = true;
            noOfKeywordsTxt.Visible = true;
            essayKeywordsLbl.Visible = true;
            essayInstructionLbl.Visible = true;
            essayAnsTxt.Visible = true;
        }

        private void HideEssayTypeControls()
        {
            txtTypeAnswerLbl.Visible = false;
            textTypeAnswerTxt.Visible = false;
            noOfWordsLbl.Visible = false;
            noOfKeywordsTxt.Visible = false;
            essayKeywordsLbl.Visible = false;
            essayInstructionLbl.Visible = false;
            essayAnsTxt.Visible = false;
        }

        private void ShowTextTypeControls()
        {
            quesTxt.Visible = true;
            label2.Visible = true;
            textTypeAnswerTxt.Visible = true;
            txtTypeAnswerLbl.Visible = true;
            txtTypeAnswerLbl.Text = "Answer :";
        }

        private void HideTextTypeControls()
        {
            quesTxt.Visible = false;
            textTypeAnswerTxt.Visible = false;
            txtTypeAnswerLbl.Visible = false;
        }         
    }
}
