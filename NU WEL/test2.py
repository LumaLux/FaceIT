#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Mon Jun 12 14:21:40 2017

@author: franktieck
"""

import face_recognition
import os
import shutil

def facecompare(datetime):
    folder = "./Processed/"
    
    dirs = os.listdir(folder + "inf1")
    i=0
    if dirs == []:
        for filename in os.listdir(folder + datetime):
            i+=1
            os.makedirs(folder + "inf1/" + "%02d" % (i, ))
            os.rename(folder + datetime + "/" + filename, folder + "inf1/" + "%02d" % (i, ) + "/" + datetime)
            print("new student made")
    else:
        for filename in os.listdir(folder + datetime):
            frank_image = face_recognition.load_image_file(folder + datetime + "/" + filename)
            frank_face_encoding = face_recognition.face_encodings(frank_image)[0]
            searching = True
            i = 0
            while i < len(dirs) and searching:
                dirs2 = os.listdir(folder + "inf1/" + dirs[i])
                unknown_image = face_recognition.load_image_file(folder + "inf1/" + dirs[i] + "/" + dirs2[0])
                unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]
                known_faces = [
                     frank_face_encoding
                ] 
                results = face_recognition.compare_faces(known_faces, unknown_face_encoding)
                
                if results[0]:
                    os.rename(folder + datetime + "/" + filename, folder + "inf1/" + dirs[i] + "/" + datetime)
                    searching = False
                else:
                    i+=1
            if searching:
                os.makedirs(folder + "inf1/" + "%02d" % (len(dirs)+1, ))
                os.rename(folder + datetime + "/" + filename, folder + "inf1/" + "%02d" % (len(dirs)+1, ) + "/" + datetime)
                print("new student made")
    shutil.rmtree(folder + datetime)