#pragma once

#include "platform_utils.h"

#if defined(SK_OS_LINUX)
#include <pthread.h>
#include <X11/keysym.h>

namespace sk {

bool  linux_init      ();
bool  linux_start     ();
void  linux_stop      ();
void  linux_shutdown  ();
void  linux_step_begin();
void  linux_step_end  ();
void  linux_vsync     ();

void  linux_finish_openxr_init();

void linux_resize(int width, int height);

bool  linux_get_cursor(vec2 &out_pos);
bool  linux_key_down  (key_ key);
float linux_get_scroll();
void  linux_set_cursor(vec2 window_pos);

} // namespace sk

#endif