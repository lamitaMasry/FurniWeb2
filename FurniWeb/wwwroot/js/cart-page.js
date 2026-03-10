import { getCart, setQty, removeItem, cartCount } from "./cart-store.js";

function money(n) {
    const num = Number(n || 0);
    return `$${num.toFixed(2)}`;
}

async function fetchProducts() {
    const res = await fetch("/api/products");
    if (!res.ok) throw new Error("Failed to load products.");
    return await res.json();
}

function updateBadges() {
    document.querySelectorAll("[data-cart-count]").forEach(el => {
        el.textContent = String(cartCount());
    });
}

function calcTotal(items) {
    return items.reduce((sum, i) => sum + (Number(i.lineTotal) || 0), 0);
}

async function render() {
    const tbody = document.querySelector("#cart-items");
    const subtotalEl = document.querySelector("#cart-subtotal");
    const totalEl = document.querySelector("#cart-total");

    if (!tbody) return;

    const cart = getCart();
    if (cart.length === 0) {
        tbody.innerHTML = `
      <tr>
        <td colspan="6" class="text-center">Your cart is empty.</td>
      </tr>
    `;
        if (subtotalEl) subtotalEl.textContent = money(0);
        if (totalEl) totalEl.textContent = money(0);
        updateBadges();
        return;
    }

    const products = await fetchProducts();
    const map = new Map(products.map(p => [p.id, p]));

    const items = cart.map(ci => {
        const p = map.get(ci.productId);
        const name = p?.name ?? `Product #${ci.productId}`;
        const price = Number(p?.price ?? 0);
        const image = p?.imageUrl ?? p?.image ?? "";
        const qty = Number(ci.quantity || 0);
        const lineTotal = price * qty;

        return {
            productId: ci.productId,
            name,
            price,
            image,
            quantity: qty,
            lineTotal
        };
    });

    tbody.innerHTML = items.map(i => `
    <tr data-id="${i.productId}">
      <td class="product-thumbnail">
        ${i.image ? `<img src="${i.image}" alt="" class="img-fluid">` : ""}
      </td>
      <td class="product-name">
        <h2 class="h5 text-black">${i.name}</h2>
      </td>
      <td>${money(i.price)}</td>
      <td style="max-width: 180px;">
        <div class="input-group d-flex align-items-center">
          <button class="btn btn-outline-black js-dec" type="button">−</button>
          <input class="form-control text-center js-qty" value="${i.quantity}" inputmode="numeric" />
          <button class="btn btn-outline-black js-inc" type="button">+</button>
        </div>
      </td>
      <td>${money(i.lineTotal)}</td>
      <td><button class="btn btn-black btn-sm js-remove" type="button">X</button></td>
    </tr>
  `).join("");

    const total = calcTotal(items);
    if (subtotalEl) subtotalEl.textContent = money(total);
    if (totalEl) totalEl.textContent = money(total);

    updateBadges();
}

document.addEventListener("click", async (e) => {
    const row = e.target.closest("tr[data-id]");
    if (!row) return;

    const id = Number(row.dataset.id);
    const cart = getCart();
    const item = cart.find(x => x.productId === id);
    if (!item) return;

    if (e.target.closest(".js-inc")) setQty(id, Number(item.quantity) + 1);
    if (e.target.closest(".js-dec")) setQty(id, Number(item.quantity) - 1);
    if (e.target.closest(".js-remove")) removeItem(id);

    await render();
});

document.addEventListener("change", async (e) => {
    const row = e.target.closest("tr[data-id]");
    if (!row) return;
    if (!e.target.classList.contains("js-qty")) return;

    const id = Number(row.dataset.id);
    const qty = Number(e.target.value);

    if (!Number.isFinite(qty) || qty <= 0) removeItem(id);
    else setQty(id, qty);

    await render();
});

render().catch(err => alert(err?.message || "Cart error"));