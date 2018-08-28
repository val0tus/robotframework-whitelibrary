import sys
import os
import clr
sys.path.append(os.path.join(os.path.dirname(os.path.realpath(__file__)), 'bin', 'Debug'))
clr.AddReference('WhiteLibrary') #include full path to Dll if required
from WhiteLibrary import WhiteLibrary
whitelib = WhiteLibrary()


class WhiteLibrary(object):
    def run_keyword(self, name, args):
        return whitelib.RunKeyword(name, args)

    def get_keyword_names(self):
        return whitelib.GetKeywordNames()

    def get_keyword_arguments(self, name):
        return whitelib.GetKeywordArguments(name)

    def get_keyword_documentation(self, name):
        pass
