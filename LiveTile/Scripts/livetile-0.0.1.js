(function ($) {
    var selectedTile;
    $.fn.extend({
        liveTile: function (datasource) {
            var defaults = ['sample'];
            var options = $.extend(defaults, datasource);

            return this.each(function () {
                var tileData = options;
                var $this = $(this);
                var newTilePosition = 0;
                var timerId = -1;

                $this
                .mouseenter(function () {
                    $this.find('.tilecontent').removeClass('tilecontenthover').addClass('tilecontenthover');
                    $this.find('.tilelabel').removeClass('tilelabelhover').addClass('tilelabelhover');
                    $this.css('cursor', 'pointer');
                    if (timerId == -1) {
                        timerId = setInterval(function () {
                            var itemPos = tileData.length - newTilePosition - 1;
                            if (itemPos < 0) {
                                newTilePosition = 0;
                                itemPos = tileData.length - newTilePosition - 1;
                            }
                            var tilecontentid = $this.find('.tilecontenttext').attr('id');
                            smoothAdd(tilecontentid, tileData[itemPos]);
                            newTilePosition++;
                        }
                    , 2000);
                    }
                })

                .mouseleave(function () {
                    $this.find('.tilecontent').removeClass('tilecontenthover');
                    if ($this != selectedTile) {
                        $this.find('.tilelabel').removeClass('tilelabelhover');
                    }
                    $this.css('cursor', 'auto');
                })
                .click(function () {
                    tileClickHandler($this);
                });

                tileClickHandler = function (parent) {
                    $('#contentTitle').text(parent.find('.tilelabel').text());
                    selectTile(parent);
                }

                selectTile = function (parent) {
                    deselectTile(selectedTile);
                    selectedTile = parent;
                    $(parent).find('.tilelabel').addClass('tilelabelhover');
                }

                deselectTile = function (parent) {
                    if (parent != null) {
                        $(parent).find('.tilelabel').removeClass('tilelabelhover');
                    }
                } 

                /*
                This function has been taken from http://www.fiveminuteargument.com/scrolling-list-demo.html
                with permission of author.
                */
                function smoothAdd(id, text) {
                    var el = $('#' + id);
                    var h = el.height();

                    el.css({
                        height: h,
                        overflow: 'hidden'
                    });

                    var ulPaddingTop = parseInt(el.css('padding-top'));
                    var ulPaddingBottom = parseInt(el.css('padding-bottom'));

                    el.prepend('<li>' + text + '</li>');

                    var first = $('li:first', el);
                    var last = $('li:last', el);
                    var foh = first.outerHeight();
                    var heightDiff = foh - last.outerHeight();
                    var oldMarginTop = first.css('margin-top');

                    first.css({
                        marginTop: 0 - foh,
                        position: 'relative',
                        top: 0 - ulPaddingTop
                    });

                    last.css('position', 'relative');

                    el.animate({ height: h + heightDiff }, 1500)

                    first.animate({ top: 0 }, 250, function () {
                        first.animate({ marginTop: oldMarginTop }, 1000, function () {
                            last.animate({ top: ulPaddingBottom }, 250, function () {
                                last.remove();

                                el.css({
                                    height: 'auto',
                                    overflow: 'visible'
                                });
                            });
                        });
                    });
                }

            });
        }
    });
})(jQuery);