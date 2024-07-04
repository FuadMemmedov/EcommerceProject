let addToBasketBtns = document.querySelectorAll(".add-to-basket");

addToBasketBtns.forEach(btn => btn.addEventListener("click", function (e) {
    let url = btn.getAttribute("href");

    e.preventDefault();

    fetch(url)
        .then(response => response.json())
        .then(data => {
            let subtotal = 0;
            document.querySelector("#basket-items").innerHTML = "";

            if (data.length === 0) {
                document.querySelector(".icon-cart span").innerHTML = "0";
                return;
            }

            document.querySelector(".icon-cart span").innerHTML = data.length;

            data.forEach(x => {
                let itemTotal = (x.price - x.price * x.discountPercent / 100) * x.count;
                subtotal += itemTotal;

                document.querySelector("#basket-items").innerHTML += `
                    <li data-id="${x.id}">
                        <div class="img-product">
                            <img src="/uploads/products/${x.imageUrl}" alt="">
                        </div>
                        <div class="info-product">
                            <div class="name">${x.name}</div>
                            <div class="price">
                                <span class="count">${x.count} x</span>
                                <span class="item-price">$${x.price}</span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </li>
                `;
            });

            document.querySelector("#basket-items").innerHTML += `
                <div class="total">
                    <span>Subtotal:</span>
                    <span class="price" id="basket-subtotal">$${subtotal.toFixed(2)}</span>
                </div>
                <div class="btn-cart">
                    <a href="/shop/showbasket" class="view-cart" title="">View Cart</a>
                    <a href="/shop/checkout" class="check-out" title="">Checkout</a>
                </div>
            `;
        });
}));

