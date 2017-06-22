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
import cv2
import numpy as np

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
            unknown_image = face_recognition.load_image_file(temp + filename)
            unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]
            searching = True
            i = 0
            while i < len(dirs) and searching:
                dirs2 = os.listdir(folder + dirs[i])
                index = 0
                size = 0
                count = 0
                for file in dirs2:
                    im = cv2.imread(folder + dirs[i] + "/" + file)
                    height = np.size(im, 0)
                    width = np.size(im, 1)
                    tsize = width + height
                    if tsize > size:
                        size = tsize
                        count = index
                    index+=1
                print(dirs2[count])
                known_image = face_recognition.load_image_file(folder + dirs[i] + "/" + dirs2[count])
                known_face_encoding = face_recognition.face_encodings(known_image)[0]
                known_faces = [
                     known_face_encoding
                ] 
                results = face_recognition.compare_faces(known_faces, unknown_face_encoding)
                
                if results[0]:
                    if not os.path.exists(folder + dirs[i] + "/" + datetime):
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
