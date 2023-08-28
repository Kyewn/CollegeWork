import nltk
import string
import random
import warnings
from sklearn.metrics.pairwise import cosine_similarity
from sklearn.feature_extraction.text import TfidfVectorizer


class ChatBot:
    def __init__(self, sentences):
        if type(sentences) != type(list()):
            self.sentence_list = nltk.sent_tokenize(sentences)
        else:
            self.sentence_list = sentences
        # nltk.download('stopwords')
        # nltk.download('punkt')
        # nltk.download('wordnet')
        self.stop_words = set(nltk.corpus.stopwords.words('english'))
        self.stop_words.update(['ha', 'le', 'u', 'wa'])
        self.refine_sentences()

        self.lemmatizer = nltk.stem.WordNetLemmatizer()
        self.remove_punctuation = dict((ord(punctuation), None)
                                       for punctuation in string.punctuation)
        warnings.filterwarnings("ignore")
        self.greeting_input_texts = ("hi",
                                     "hey", "heys", "hello", "morning", "evening", "greetings")
        self.greeting_replie_texts = ["hey",
                                      "hey how you?", "hello there",  "Welcome, how are you"]

    def filter_sentence(self, sentence):
        word_tokens = nltk.tokenize.word_tokenize(sentence)
        sent_list = [w for w in word_tokens if not w in self.stop_words]
        return ' '.join(sent_list)

    def refine_sentences(self):
        self.filtered_sentences = []
        for sentence in self.sentence_list:
            self.filtered_sentences.append(self.filter_sentence(sentence))

    def LemmatizeWords(self, words):
        return [self.lemmatizer.lemmatize(word) for word in words]

    def RemovePunctuations(self, text):
        return self.LemmatizeWords(nltk.word_tokenize(text.lower().translate(self.remove_punctuation)))

    def reply_greeting(self, text):

        for word in text.split():
            if word.lower() in self.greeting_input_texts:
                return random.choice(self.greeting_replie_texts)

    def give_reply(self, user_input):
        chatbot_response = ''
        self.filtered_sentences.append(user_input)
        word_vectors = TfidfVectorizer(
            tokenizer=self.RemovePunctuations, stop_words='english')
        vecrorized_words = word_vectors.fit_transform(self.filtered_sentences)
        similarity_values = cosine_similarity(
            vecrorized_words[-1], vecrorized_words)
        similar_sentence_number = similarity_values.argsort()[0][-2]
        similar_vectors = similarity_values.flatten()
        similar_vectors.sort()
        matched_vector = similar_vectors[-2]
        if(matched_vector == 0):
            chatbot_response = chatbot_response+"I am sorry! I don't understand you"
            return chatbot_response
        else:
            chatbot_response = chatbot_response + \
                self.sentence_list[similar_sentence_number]
            return chatbot_response

    def run_bot(self, ids):
        continue_discussion = True
        print("Hello, I am Jack, I will answer your queries regarding the egg incubating system: ")
        print(f"I can tell you about incubators with id {ids}")
        while(continue_discussion == True):
            user_input = input("> ")
            user_input = self.filter_sentence(user_input)
            user_input = user_input.lower()
            if(user_input != 'bye'):
                if(user_input == 'thanks' or user_input == 'thank you very much' or user_input == 'thank you'):
                    continue_discussion = False
                    print("Jack: Most welcome!")
                else:
                    if(self.reply_greeting(user_input) != None):
                        print("Jack: "+self.reply_greeting(user_input))
                    else:
                        print("Jack: ", end="")
                        print(self.give_reply(user_input))
                        self.filtered_sentences.remove(user_input)
            else:
                continue_discussion = False
                print("Jack: Take care, bye ...")
