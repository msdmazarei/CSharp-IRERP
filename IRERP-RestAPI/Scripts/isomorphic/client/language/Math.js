/*
 * Isomorphic SmartClient
 * Version 8.2 (2011-12-05)
 * Copyright(c) 1998 and beyond Isomorphic Software, Inc. All rights reserved.
 * "SmartClient" is a trademark of Isomorphic Software, Inc.
 *
 * licensing@smartclient.com
 *
 * http://smartclient.com/license
 */
//
// Math helpers
//
isc.Math = {
    random : function (a,b) {
        if (b==null) {
            return Math.round(Math.random()*a)
        } else {
            return Math.round(Math.random()*(b-a))+a
        }
    }
}
