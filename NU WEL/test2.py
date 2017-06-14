#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Mon Jun 12 14:21:40 2017

@author: franktieck
"""

import face_recognition
import os
import time

def facecompare():
    datetime = time.strftime("%c")
    klas = "./Processed/inf1/"
    temp = "./temp/"
    
    dirs = os.listdir(klas)
    i=0
    c = len(dirs)
    if dirs == []:
        for filename in os.listdir(temp):
            i+=1
            os.makedirs(klas + "%02d" % (i, ))
            os.rename(temp  + filename, klas + "%02d" % (i, ) + "/" + datetime)
            print("new student made")
    else:
        for filename in os.listdir(temp):
            frank_image = face_recognition.load_image_file(temp + filename)
            frank_face_encoding = face_recognition.face_encodings(frank_image)[0]
            searching = True
            i = 0
            while i < len(dirs) and searching:
                dirs2 = os.listdir(klas + dirs[i])
                unknown_image = face_recognition.load_image_file(klas + dirs[i] + "/" + dirs2[0])
                unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]
                known_faces = [
                     frank_face_encoding
                ] 
                results = face_recognition.compare_faces(known_faces, unknown_face_encoding)
                
                if results[0]:
                    os.rename(temp + filename, klas + dirs[i] + "/" + datetime)
                    searching = False
                else:
                    i+=1
            if searching:
                c+=1
                os.makedirs(klas + "%02d" % (c, ))
                os.rename(temp + filename, klas + "%02d" % (c, ) + "/" + datetime)
                print("new student made")