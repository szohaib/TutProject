(function () {
    'use strict';

    angular
        .module('ms.admissions')
        .directive('themeInit', themeInit);

    themeInit.$inject = [];
    function themeInit() {
        // Usage:
        //
        // Creates:
        //
        var directive = {
            link: link,
            scope: {
            }
        };
        return directive;

        function link(scope, element, attrs) {
            var md = {
                misc: {
                    navbar_menu_visible: 0,
                    active_collapse: true,
                    disabled_collapse_init: 0,
                },

                checkSidebarImage: function () {
                    var $sidebar = $('.sidebar');
                    var image_src = $sidebar.data('image');

                    if (image_src !== undefined) {
                        var sidebar_container = '<div class="sidebar-background" style="background-image: url(' + image_src + ') "/>'
                        $sidebar.append(sidebar_container);
                    }
                },

                checkScrollForTransparentNavbar: debounce(function () {
                    if ($(document).scrollTop() > 260) {
                        if (transparent) {
                            transparent = false;
                            $('.navbar-color-on-scroll').removeClass('navbar-transparent');
                        }
                    } else {
                        if (!transparent) {
                            transparent = true;
                            $('.navbar-color-on-scroll').addClass('navbar-transparent');
                        }
                    }
                }, 17),

                initSidebarsCheck: function () {
                    if ($(window).width() <= 991) {
                        if ($sidebar.length != 0) {
                            md.initRightMenu();
                        }
                    }
                },

                initRightMenu: debounce(function () {
                    var $sidebar_wrapper = $('.sidebar-wrapper');

                    if (!mobile_menu_initialized) {
                        var $navbar = $('nav').find('.navbar-collapse').children('.navbar-nav.navbar-right');

                        var mobile_menu_content = '';

                        var nav_content = $navbar.html();

                        var nav_content = '<ul class="nav nav-mobile-menu">' + nav_content + '</ul>';

                        var navbar_form = $('nav').find('.navbar-form').get(0).outerHTML;

                        var $sidebar_nav = $sidebar_wrapper.find(' > .nav');

                        // insert the navbar form before the sidebar list
                        var $nav_content = $(nav_content);
                        var $navbar_form = $(navbar_form);
                        $nav_content.insertBefore($sidebar_nav);
                        $navbar_form.insertBefore($nav_content);

                        $(".sidebar-wrapper .dropdown .dropdown-menu > li > a").click(function (event) {
                            event.stopPropagation();

                        });

                        // simulate resize so all the charts/maps will be redrawn
                        window.dispatchEvent(new Event('resize'));

                        mobile_menu_initialized = true;
                    } else {
                        if ($(window).width() > 991) {
                            // reset all the additions that we made for the sidebar wrapper only if the screen is bigger than 991px
                            $sidebar_wrapper.find('.navbar-form').remove();
                            $sidebar_wrapper.find('.nav-mobile-menu').remove();

                            mobile_menu_initialized = false;
                        }
                    }
                }, 200),


                startAnimationForLineChart: function (chart) {

                    chart.on('draw', function (data) {
                        if (data.type === 'line' || data.type === 'area') {
                            data.element.animate({
                                d: {
                                    begin: 600,
                                    dur: 700,
                                    from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
                                    to: data.path.clone().stringify(),
                                    easing: Chartist.Svg.Easing.easeOutQuint
                                }
                            });
                        } else if (data.type === 'point') {
                            seq++;
                            data.element.animate({
                                opacity: {
                                    begin: seq * delays,
                                    dur: durations,
                                    from: 0,
                                    to: 1,
                                    easing: 'ease'
                                }
                            });
                        }
                    });

                    seq = 0;
                },
                startAnimationForBarChart: function (chart) {

                    chart.on('draw', function (data) {
                        if (data.type === 'bar') {
                            seq2++;
                            data.element.animate({
                                opacity: {
                                    begin: seq2 * delays2,
                                    dur: durations2,
                                    from: 0,
                                    to: 1,
                                    easing: 'ease'
                                }
                            });
                        }
                    });

                    seq2 = 0;
                }
            }
            var isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;

            if (isWindows) {
                // if we are on windows OS we activate the perfectScrollbar function
                $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                $('html').addClass('perfect-scrollbar-on');
            } else {
                $('html').addClass('perfect-scrollbar-off');
            }

            var searchVisible = 0;
            var transparent = true;

            var transparentDemo = true;
            var fixedTop = false;

            var mobile_menu_visible = 0,
                mobile_menu_initialized = false,
                toggle_initialized = false,
                bootstrap_nav_initialized = false;

            var seq = 0,
                delays = 80,
                durations = 500;
            var seq2 = 0,
                delays2 = 80,
                durations2 = 500;


            var $sidebar = $('.sidebar');

            $.material.init();

            var window_width = $(window).width();

            md.initSidebarsCheck();

            // check if there is an image set for the sidebar's background
            md.checkSidebarImage();

            //  Activate the tooltips
            $('[rel="tooltip"]').tooltip();

            $('.form-control').on("focus", function () {
                $(this).parent('.input-group').addClass("input-group-focus");
            }).on("blur", function () {
                $(this).parent(".input-group").removeClass("input-group-focus");
            });


            $(document).on('click', '.navbar-toggle', function () {
                var $toggle = $(this);

                if (mobile_menu_visible == 1) {
                    $('html').removeClass('nav-open');

                    $('.close-layer').remove();
                    setTimeout(function () {
                        $toggle.removeClass('toggled');
                    }, 400);

                    mobile_menu_visible = 0;
                } else {
                    setTimeout(function () {
                        $toggle.addClass('toggled');
                    }, 430);

                    var div = '<div id="bodyClick"></div>';
                    $(div).appendTo('body').click(function () {
                        $('html').removeClass('nav-open');
                        mobile_menu_visible = 0;
                        setTimeout(function () {
                            $toggle.removeClass('toggled');
                            $('#bodyClick').remove();
                        }, 550);
                    });

                    $('html').addClass('nav-open');
                    mobile_menu_visible = 1;

                }
            });

            // activate collapse right menu when the windows is resized
            $(window).resize(function () {
                md.initSidebarsCheck();
                // reset the seq for charts drawing animations
                seq = seq2 = 0;
            });




            // Returns a function, that, as long as it continues to be invoked, will not
            // be triggered. The function will be called after it stops being called for
            // N milliseconds. If `immediate` is passed, trigger the function on the
            // leading edge, instead of the trailing.

            function debounce(func, wait, immediate) {
                var timeout;
                return function () {
                    var context = this,
                        args = arguments;
                    clearTimeout(timeout);
                    timeout = setTimeout(function () {
                        timeout = null;
                        if (!immediate) func.apply(context, args);
                    }, wait);
                    if (immediate && !timeout) func.apply(context, args);
                };
            };
        }
    }
    /* @ngInject */
    function ControllerController() {

    }
})();