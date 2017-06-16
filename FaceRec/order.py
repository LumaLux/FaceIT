#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Mon Jun 12 14:21:40 2017

@author: franktieck
"""

import face_recognition
import os
import time
import database

def facecompare(klas, periode):
    datetime = time.strftime("%c")
    folder = "./Processed/" + klas + "-" + periode + "/"
    temp = "./temp/"
    
    dirs = os.listdir(folder)
    i=0
    if dirs == []:
        for filename in os.listdir(temp):
            i+=1
            os.makedirs(folder + "%02d" % (i, ))
            os.rename(temp  + filename, folder + "%02d" % (i, ) + "/" + datetime)
            database.newStudent(klas, periode, "%02d" % (i, ))
            print("new student made")
    else:
        for filename in os.listdir(temp):
            frank_image = face_recognition.load_image_file(temp + filename)
            frank_face_encoding = face_recognition.face_encodings(frank_image)[0]
            searching = True
            i = 0
            while i < len(dirs) and searching:
                dirs2 = os.listdir(folder + dirs[i])
                unknown_image = face_recognition.load_image_file(folder + dirs[i] + "/" + dirs2[0])
                unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]
                known_faces = [
                     frank_face_encoding
                ] 
                results = face_recognition.compare_faces(known_faces, unknown_face_encoding)
                
                if results[0]:
                    os.rename(temp + filename, folder + dirs[i] + "/" + datetime)
                    database.AddPresence(dirs[i], klas, periode)
                    searching = False
                else:
                    i+=1
            if searching:
                os.makedirs(folder + "%02d" % (len(dirs)+1, ))
                os.rename(temp + filename, folder + "%02d" % (len(dirs)+1, ) + "/" + datetime)
                database.newStudent(klas, periode, "%02d" % (len(dirs)+1, ))
                print("new student made")

    database.dbClose()
